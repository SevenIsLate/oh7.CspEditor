using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using oh7.CspEditor.Models;

namespace oh7.CspEditor.WebApp.Pages.Item
{
    [Authorize]
    public class CreateSourceModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateSourceModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty] public CspDirectiveItem CspDirectiveItem { get; set; }
        [BindProperty] public int CspProjectId { get; set; }
        public CspDirectiveItemType Type { get; set; }

        public async Task<IActionResult> OnGet(int projectId, int directiveId, int typeId)
        {
            CspProjectId = projectId;
            Type = await _context.CspDirectiveItemTypes.FindAsync(typeId).ConfigureAwait(false);
            CspDirectiveItem = new CspDirectiveItem { CspDirectiveId = directiveId, CspDirectiveItemTypeId = typeId };
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

            await _context.CspDirectiveItems.AddAsync(CspDirectiveItem).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return RedirectToPage(Directive.IndexModel.GetMyPath, new { ProjectId = CspProjectId });
        }
    }
}