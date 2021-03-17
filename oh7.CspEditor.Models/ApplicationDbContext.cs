using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace oh7.CspEditor.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CspProject> CspProjects { get; set; }
        public DbSet<CspDirective> CspDirectives { get; set; }
        public DbSet<CspDirectiveItem> CspDirectiveItems { get; set; }
        public DbSet<CspDirectiveItemType> CspDirectiveItemTypes { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }
        public DbSet<CspEditorSettings> CspEditorSettings { get; set; }
    }
}