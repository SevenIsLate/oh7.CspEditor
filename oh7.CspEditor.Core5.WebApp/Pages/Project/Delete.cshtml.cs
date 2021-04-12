using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using oh7.CspEditor.Library.Helpers;
using oh7.CspEditor.Models;

namespace oh7.CspEditor.Core5.WebApp.Pages.Project
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty] public CspProject CspProject { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CspProject = await _context.CspProjects.FirstOrDefaultAsync(m => m.Id == id);

            if (CspProject == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helper = new CspEditorHelper(_context);
            await helper.DeleteProject(id.Value).ConfigureAwait(false);

            return RedirectToPage("./Index");
        }
    }
}