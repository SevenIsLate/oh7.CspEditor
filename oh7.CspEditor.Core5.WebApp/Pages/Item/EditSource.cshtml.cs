using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using oh7.CspEditor.Models;

namespace oh7.CspEditor.Core5.WebApp.Pages.Item
{
    public class EditSourceModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditSourceModel(ApplicationDbContext context)
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

            if (!Uri.TryCreate(CspDirectiveItem.Content, UriKind.Absolute, out var result))
            {
                ModelState.AddModelError("", "Url is not valid, please check it and try again!");
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