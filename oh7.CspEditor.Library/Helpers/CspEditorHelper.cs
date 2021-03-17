using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using oh7.CspEditor.Models;

namespace oh7.CspEditor.Library.Helpers
{
    public class CspEditorHelper
    {
        private readonly ApplicationDbContext _context;

        public CspEditorHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteProject(int projectId)
        {
            var project = await _context
                .CspProjects
                .Include(i => i.CspDirectives)
                .ThenInclude(i => i.Items)
                .FirstOrDefaultAsync(x => x.Id == projectId)
                .ConfigureAwait(false);

            _context.CspProjects.Remove(project);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}