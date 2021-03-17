using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using oh7.CspEditor.Models;

namespace oh7.CspEditor.WebApp.Pages.Item
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty] public CspDirectiveItem CspDirectiveItem { get; set; }

        [BindProperty] public int CspProjectId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int projectId)
        {
            if (id == null) return NotFound();

            CspProjectId = projectId;
            CspDirectiveItem = await _context
                .CspDirectiveItems
                .Include(c => c.CspDirective)
                .Include(c => c.CspDirectiveItemType)
                .FirstOrDefaultAsync(m => m.Id == id)
                .ConfigureAwait(false);

            if (CspDirectiveItem == null) return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();

            CspDirectiveItem = await _context.CspDirectiveItems.FindAsync(id).ConfigureAwait(false);

            if (CspDirectiveItem == null) return RedirectToPage(Directive.IndexModel.GetMyPath, new {ProjectId = CspProjectId});

            _context.CspDirectiveItems.Remove(CspDirectiveItem);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return RedirectToPage(Directive.IndexModel.GetMyPath, new {ProjectId = CspProjectId});
        }
    }
}