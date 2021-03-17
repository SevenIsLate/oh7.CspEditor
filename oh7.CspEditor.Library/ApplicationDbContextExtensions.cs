using System.Linq;
using oh7.CspEditor.Models;

namespace oh7.CspEditor.Library
{
    public static class ApplicationDbContextExtensions
    {
        public static string GetEditorSetting(this ApplicationDbContext context, string key)
        {
            var settings = context.CspEditorSettings.FirstOrDefault(x => x.Key == key);

            return settings?.Value ?? string.Empty;
        }
    }
}