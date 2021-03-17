using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using oh7.CspEditor.Models;

namespace oh7.CspEditor.WebApp.Pages.Item
{
    [Authorize]
    public class EditHashModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditHashModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty] public CspDirectiveItem CspDirectiveItem { get; set; }

        [BindProperty] public int CspProjectId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int projectId)
        {
            if (id == null) return NotFound();

            CspProjectId = projectId;
            CspDirectiveItem = await _context.CspDirectiveItems
                .Include(c => c.CspDirective)
                .Include(c => c.CspDirectiveItemType).FirstOrDefaultAsync(m => m.Id == id);

            if (CspDirectiveItem == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            if (!CspDirectiveItem.Content.StartsWith("sha"))
            {
                ModelState.AddModelError("", "Hash is not valid, please check it and try again!");
                return Page();
            }

            _context.Attach(CspDirectiveItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CspDirectiveItemExists(CspDirectiveItem.Id)) return NotFound();

                throw;
            }

            return RedirectToPage(Directive.IndexModel.GetMyPath, new {ProjectId = CspProjectId});
        }

        private bool CspDirectiveItemExists(int id)
        {
            return _context.CspDirectiveItems.Any(e => e.Id == id);
        }
    }
}