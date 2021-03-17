using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using oh7.CspEditor.Models;

namespace oh7.CspEditor.Library.Helpers
{
    public static class ViewHelper
    {
        public static string SpaceCreator(int spaces)
        {
            const string spaceCode = "&nbsp;";

            return new string(' ', spaces).Replace(" ", spaceCode);
        }

        public static string TagCreator(string attributeName)
        {
            return $"&lt;{attributeName}&gt;";
        }

        public static List<Tuple<string, StylingSettings>> GetAvailableStyling()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json")
                .Build();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            using var context = new ApplicationDbContext(options.Options);

            var cssStylingList = new List<Tuple<string, StylingSettings>>
            {
                new Tuple<string, StylingSettings>("Default", new StylingSettings{IsDarkTheme = false, PathToCss = context.GetEditorSetting("DefaultCssStyling")}),
                new Tuple<string, StylingSettings>("cerulean", new StylingSettings{IsDarkTheme = false, PathToCss = "/lib/node_modules/bootswatch/dist/cerulean/bootstrap.min.css"}),
                new Tuple<string, StylingSettings>("cyborg", new StylingSettings{IsDarkTheme = true, PathToCss = "/lib/node_modules/bootswatch/dist/cyborg/bootstrap.min.css"}),
                new Tuple<string, StylingSettings>("darkly", new StylingSettings{IsDarkTheme = true, PathToCss = "/lib/node_modules/bootswatch/dist/darkly/bootstrap.min.css"}),
                new Tuple<string, StylingSettings>("flatly", new StylingSettings{IsDarkTheme = false, PathToCss = "/lib/node_modules/bootswatch/dist/flatly/bootstrap.min.css"}),
                new Tuple<string, StylingSettings>("journal", new StylingSettings{IsDarkTheme = false, PathToCss = "/lib/node_modules/bootswatch/dist/journal/bootstrap.min.css"}),
                new Tuple<string, StylingSettings>("litera", new StylingSettings{IsDarkTheme = false, PathToCss = "/lib/node_modules/bootswatch/dist/litera/bootstrap.min.css"}),
                new Tuple<string, StylingSettings>("lumen", new StylingSettings{IsDarkTheme = false, PathToCss = "/lib/node_modules/bootswatch/dist/lumen/bootstrap.min.css"}),
                new Tuple<string, StylingSettings>("lux", new StylingSettings{IsDarkTheme = false, PathToCss = "/lib/node_modules/bootswatch/dist/lux/bootstrap.min.css"}),
                new Tuple<string, StylingSettings>("materia", new StylingSettings{IsDarkTheme = false, PathToCss = "/lib/node_modules/bootswatch/dist/materia/bootstrap.min.css"}),
                new Tuple<string, StylingSettings>("minty", new StylingSettings{IsDarkTheme = false, PathToCss = "/lib/node_modules/bootswatch/dist/minty/bootstrap.min.css"}),
                new Tuple<string, StylingSettings>("pulse", new StylingSettings{IsDarkTheme = true, PathToCss = "/lib/node_modules/bootswatch/dist/pulse/bootstrap.min.css"}),
                new Tuple<string, StylingSettings>("sandstone", new StylingSettings{IsDarkTheme = false, PathToCss = "/lib/node_modules/bootswatch/dist/sandstone/bootstrap.min.css"}),
                new Tuple<string, StylingSettings>("simplex", new StylingSettings{IsDarkTheme = false, PathToCss = "/lib/node_modules/bootswatch/dist/simplex/bootstrap.min.css"}),
                new Tuple<string, StylingSettings>("sketchy", new StylingSettings{IsDarkTheme = false, PathToCss = "/lib/node_modules/bootswatch/dist/sketchy/bootstrap.min.css"}),
                new Tuple<string, StylingSettings>("slate", new StylingSettings{IsDarkTheme = true, PathToCss = "/lib/node_modules/bootswatch/dist/slate/bootstrap.min.css"}),
                new Tuple<string, StylingSettings>("solar", new StylingSettings{IsDarkTheme = true, PathToCss = "/lib/node_modules/bootswatch/dist/solar/bootstrap.min.css"}),
                new Tuple<string, StylingSettings>("spacelab", new StylingSettings{IsDarkTheme = false, PathToCss = "/lib/node_modules/bootswatch/dist/spacelab/bootstrap.min.css"}),
                new Tuple<string, StylingSettings>("superhero", new StylingSettings{IsDarkTheme = true, PathToCss = "/lib/node_modules/bootswatch/dist/superhero/bootstrap.min.css"}),
                new Tuple<string, StylingSettings>("united", new StylingSettings{IsDarkTheme = false, PathToCss = "/lib/node_modules/bootswatch/dist/united/bootstrap.min.css"}),
                new Tuple<string, StylingSettings>("yeti", new StylingSettings{IsDarkTheme = false, PathToCss = "/lib/node_modules/bootswatch/dist/yeti/bootstrap.min.css"})
            };

            return cssStylingList;
        }
    }
}