using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using oh7.CspEditor.Models;

namespace oh7.CspEditor.Library
{
    public static class DatabaseSeeder
    {
        public static async Task Initialize(ApplicationDbContext context)
        {
            if (context.Database.IsSqlServer())
            {
                await context.Database.MigrateAsync();
            }
        }

        public static async Task Seed(ApplicationDbContext context)
        {
            if (!await context.Users.AnyAsync())
            {
                await context.Users.AddAsync(
                    new IdentityUser("oistein.hay@bekk.no")
                    {
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "597ce84d-5dbb-4a43-9dd2-5bed793df77b",
                        Email = "oistein@oh7.no",
                        EmailConfirmed = true,
                        Id = "e788692a-0f4e-4c17-9598-db691d64d89d",
                        LockoutEnabled = true,
                        LockoutEnd = null,
                        NormalizedEmail = "OISTEIN@OH7.NO",
                        NormalizedUserName = "OISTEIN@OH7.NO",
                        PasswordHash =
                            "AQAAAAEAACcQAAAAEDLxhB/sTiKmmPpwi167EwISI/Fswpm5ociOIlaaHn+VVhMGYGd9YZbp1vjoqQNCUA==",
                        PhoneNumber = "+4748127526",
                        PhoneNumberConfirmed = true,
                        SecurityStamp = "IC3YJDRLIYZ5O6F2U22C7UFADXMGF7MU",
                        TwoFactorEnabled = false,
                        UserName = "oistein@oh7.no"
                    });
            }

            if (!await context.CspDirectiveItemTypes.AnyAsync())
            {
                await context.CspDirectiveItemTypes.AddAsync(new CspDirectiveItemType { Id = 1, Name = "Source" });
                await context.CspDirectiveItemTypes.AddAsync(new CspDirectiveItemType { Id = 2, Name = "Hash" });
            }

            if (!await context.CspEditorSettings.AnyAsync())
            {
                await context.CspEditorSettings.AddAsync(new CspEditorSettings
                {
                    Id = 1,
                    Key = "DefaultCssStyling",
                    Value = "/lib/bootstrap/dist/css/bootstrap.min.css"
                });
            }

            await context.SaveChangesAsync();
        }
    }
}