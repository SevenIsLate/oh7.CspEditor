using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using oh7.CspEditor.Library.Helpers;
using oh7.CspEditor.Models;

namespace oh7.CspEditor.WebApp.Pages.Project
{
    [Authorize]
    public class ImportModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ImportModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty] public string Csp { get; set; }
        [BindProperty] public int CspProjectId { get; set; }
        [BindProperty] public CspProject CspProject { get; set; }

        public void OnGet(int projectId)
        {
            CspProjectId = projectId;

            CspProject = _context.CspProjects.Find(projectId);
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            if (string.IsNullOrWhiteSpace(Csp))
            {
                ModelState.AddModelError("", "CSP field missing!");
                return Page();
            }

            var parser = new CspParser();

            if (parser.ParseCsp(CspProjectId, Csp)) return RedirectToPage("/Directive/Index", new { projectId = CspProjectId });

            ModelState.AddModelError("", "Can't parse CSP!");

            return Page();
        }
    }
}