using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using oh7.CspEditor.Models;

namespace oh7.CspEditor.Library.Helpers
{
    public class UserSettingsHelper
    {
        private readonly ApplicationDbContext _context;

        public UserSettingsHelper()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json")
                .Build();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            _context = new ApplicationDbContext(options.Options);
        }

        public async Task<string> GetUserSetting(string ownerId, string key)
        {
            var userSettings = await _context.UserSettings.FirstOrDefaultAsync(x => x.OwnerId == ownerId && x.Key == key).ConfigureAwait(false);
            return userSettings != null ? userSettings.Value : _context.GetEditorSetting(CspEditorSettingsConstants.DefaultCssStyle);
        }

        public async Task SaveUserSetting(string ownerId, string key, string value)
        {
            var existingSetting = await _context
                .UserSettings
                .FirstOrDefaultAsync(x => x.OwnerId == ownerId && x.Key == key)
                .ConfigureAwait(false);

            if (existingSetting != null)
            {
                existingSetting.Value = value;
            }
            else
            {
                await _context.UserSettings.AddAsync(new UserSettings
                {
                    OwnerId = ownerId,
                    Key = key,
                    Value = value
                }).ConfigureAwait(false);
            }

            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}