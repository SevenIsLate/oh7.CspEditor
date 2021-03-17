using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using oh7.CspEditor.Library.Helpers;
using oh7.CspEditor.Models;

namespace oh7.CspEditor.WebApp.Pages.Project
{
    [Authorize]
    public class BuildModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public BuildModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CspDirective> CspDirectives { get; set; }
        public string CspOutput { get; set; }

        public async Task OnGet(int projectId)
        {
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
    }
}