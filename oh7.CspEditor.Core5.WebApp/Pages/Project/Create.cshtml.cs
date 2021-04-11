using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using oh7.CspEditor.Library.Helpers;
using oh7.CspEditor.Models;

namespace oh7.CspEditor.Core5.WebApp.Pages.Project
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty] public CspProject CspProject { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            CspProject.OwnerId = User.GetLoggedInUserId<string>();

            await _context.CspProjects.AddAsync(CspProject).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            await InitializeDirectives(CspProject).ConfigureAwait(false);

            return RedirectToPage("./Index");
        }

        private async Task InitializeDirectives(CspProject project)
        {
            await _context.CspDirectives.AddRangeAsync(CspDirectiveHelper.GetDefaultCspDirectivesForProject(project.Id)).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}