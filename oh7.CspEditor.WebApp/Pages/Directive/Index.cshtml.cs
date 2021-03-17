using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using oh7.CspEditor.Library.Helpers;
using oh7.CspEditor.Models;

namespace oh7.CspEditor.WebApp.Pages.Directive
{
    [Authorize]
    public class IndexModel : BasePageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public static string GetMyPath => "/Directive/Index";

        public CspProject CspProject { get; set; }
        public List<CspDirective> CspDirectives { get; set; }
        public List<CspDirectiveItemType> ItemTypes { get; set; }
        public string CspOutput { get; set; }
        public async Task OnGetAsync(int projectId)
        {
            ItemTypes = await _context
                .CspDirectiveItemTypes
                .ToListAsync()
                .ConfigureAwait(false);
            CspProject = await _context
                .CspProjects
                .FindAsync(projectId)
                .ConfigureAwait(false);
            CspDirectives = await _context
                .CspProjects
                .Where(x => x.Id == projectId)
                .Include(i => i.CspDirectives)
                .ThenInclude(i => i.Items)
                .SelectMany(x => x.CspDirectives)
                .ToListAsync()
                .ConfigureAwait(false);

            CspOutput = CspDirectives.Count > 0 ? CspDirectiveHelper.BuildCspDirective(CspDirectives) : string.Empty;
        }

        public ActionResult OnPostSend()
        {
            var postedData = GetPostData();

            var directive = _context.CspDirectives.Find(postedData.DirectiveId);

            switch (postedData.PropertyToChange)
            {
                case nameof(directive.Enabled):
                    {
                        directive.Enabled = postedData.Value;
                        break;
                    }
                case nameof(directive.None):
                    {
                        directive.None = postedData.Value;
                        break;
                    }
                case nameof(directive.Self):
                    {
                        directive.Self = postedData.Value;
                        break;
                    }
                case nameof(directive.StrictDynamic):
                    {
                        directive.StrictDynamic = postedData.Value;
                        break;
                    }
                case nameof(directive.UnsafeEval):
                    {
                        directive.UnsafeEval = postedData.Value;
                        break;
                    }
                case nameof(directive.UnsafeInline):
                    {
                        directive.UnsafeInline = postedData.Value;
                        break;
                    }
            }
            _context.SaveChanges();

            return new JsonResult($"Changed \"{postedData.PropertyToChange}\" for \"{directive.DirectiveName}\" to \"{postedData.Value}\"");
        }

        private DirectivePostData GetPostData()
        {
            var stream = new MemoryStream();

            Request.Body.CopyTo(stream);
            stream.Position = 0;

            using var reader = new StreamReader(stream);

            var requestBody = reader.ReadToEnd();

            return requestBody.Length > 0 ? JsonConvert.DeserializeObject<DirectivePostData>(requestBody) : null;
        }
    }
}