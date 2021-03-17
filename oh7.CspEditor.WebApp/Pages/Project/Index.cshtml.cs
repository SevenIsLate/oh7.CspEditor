using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using oh7.CspEditor.Models;

namespace oh7.CspEditor.WebApp.Pages.Project
{
    [Authorize]
    public class IndexModel : BasePageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CspProject> CspProject { get; set; }

        public async Task OnGetAsync()
        {
            CspProject = await _context.CspProjects.Where(x => x.OwnerId == GetUserId).ToListAsync();
        }
    }
}