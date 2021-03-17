using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using oh7.CspEditor.Models;

namespace oh7.CspEditor.Library.Helpers
{
    public class CspParser
    {
        private readonly ApplicationDbContext _context;

        public CspParser()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            _context = new ApplicationDbContext(options.Options);
        }

        public bool ParseCsp(int projectId, string csp)
        {
            var cspProject = _context.CspProjects.Find(projectId);
            var sourceCspDirectiveItemType = _context.CspDirectiveItemTypes.FirstOrDefault(x => x.Name == "Source");
            if (sourceCspDirectiveItemType == null) throw new Exception("Can't find CspDirectiveItemTypes for Source, aborting!");
            var hashCspDirectiveItemType = _context.CspDirectiveItemTypes.FirstOrDefault(x => x.Name == "Hash");
            if (hashCspDirectiveItemType == null) throw new Exception("Can't find CspDirectiveItemTypes for Hash, aborting!");

            if (cspProject == null) return false;

            if (string.IsNullOrWhiteSpace(csp)) return false;

            var categories = csp.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var category in categories)
            {
                var items = category.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (items.Length == 0) continue;

                var directiveName = items.FirstOrDefault();

                if (string.IsNullOrWhiteSpace(directiveName)) continue;

                var cspDirective = _context
                    .CspDirectives
                    .Include(i => i.Items)
                    .FirstOrDefault(x => x.DirectiveName.Equals(directiveName) && x.CspProjectId == projectId);

                if (cspDirective == null) continue;

                ResetCspDirective(cspDirective);

                var directiveItems = items.Skip(1).ToList();

                foreach (var directiveItem in directiveItems)
                {
                    cspDirective.Enabled = true;

                    var tmp = directiveItem.Replace("'", string.Empty);

                    switch (tmp.ToLowerInvariant())
                    {
                        case "self":
                            {
                                cspDirective.Self = true;
                                continue;
                            }
                        case "none":
                            {
                                cspDirective.None = true;
                                continue;
                            }
                        case "unsafe-eval":
                            {
                                cspDirective.UnsafeEval = true;
                                continue;
                            }
                        case "unsafe-inline":
                            {
                                cspDirective.UnsafeInline = true;
                                continue;
                            }
                        case "strict-dynamic":
                            {
                                cspDirective.StrictDynamic = true;
                                continue;
                            }
                    }

                    if (Uri.TryCreate(tmp.Trim(), UriKind.Absolute, out var uri))
                    {
                        cspDirective.Items.Add(new CspDirectiveItem { CspDirectiveItemTypeId = sourceCspDirectiveItemType.Id, Content = uri.ToString().TrimEnd('/') });
                    }

                    if (tmp.StartsWith("sha"))
                    {
                        cspDirective.Items.Add(new CspDirectiveItem { CspDirectiveItemTypeId = hashCspDirectiveItemType.Id, Content = tmp.Trim() });
                    }
                }

                _context.SaveChanges();
            }

            return true;
        }

        private static void ResetCspDirective(CspDirective cspDirective)
        {
            cspDirective.Enabled = false;
            cspDirective.None = false;
            cspDirective.Self = false;
            cspDirective.StrictDynamic = false;
            cspDirective.UnsafeEval = false;
            cspDirective.UnsafeInline = false;
            cspDirective.Items = new List<CspDirectiveItem>();
        }
    }
}