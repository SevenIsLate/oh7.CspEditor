using System.Collections.Generic;
using System.Linq;
using oh7.CspEditor.Models;

namespace oh7.CspEditor.Library.Helpers
{
    public static class CspDirectiveHelper
    {
        public static List<CspDirective> DefaultDirectives => new List<CspDirective>
        {
            new CspDirective {DisplayName = "Default Source", DirectiveName = "default-src", Order = 1},
            new CspDirective {DisplayName = "Child Source", DirectiveName = "child-src", Order = 8},
            new CspDirective {DisplayName = "Connect Source", DirectiveName = "connect-src", Order = 7},
            new CspDirective {DisplayName = "Font Source", DirectiveName = "font-src", Order = 6},
            new CspDirective {DisplayName = "Image Source", DirectiveName = "image-src", Order = 5},
            new CspDirective {DisplayName = "Manifest Source", DirectiveName = "manifest-src", Order = 9},
            new CspDirective {DisplayName = "Media Source", DirectiveName = "media-src", Order = 11},
            new CspDirective {DisplayName = "Object Source", DirectiveName = "object-src", Order = 4},
            new CspDirective {DisplayName = "Prefetch Source", DirectiveName = "prefetch-src", Order = 10},
            new CspDirective {DisplayName = "Script Source", DirectiveName = "script-src", Order = 2},
            new CspDirective {DisplayName = "Style Source", DirectiveName = "style-src", Order = 3}
        };

        public static List<CspDirective> GetDefaultCspDirectivesForProject(int projectId)
        {
            var defaultDirectives = DefaultDirectives;

            foreach (var defaultDirective in defaultDirectives) defaultDirective.CspProjectId = projectId;

            return defaultDirectives;
        }

        public static string BuildCspDirective(List<CspDirective> directives)
        {
            var csp = new List<string>();

            foreach (var directive in directives.Where(x => x.Enabled).OrderBy(x => x.Order))
            {
                csp.Add($"{directive.DirectiveName}");
                if (directive.None) csp.Add("'none'");
                if (directive.Self) csp.Add("'self'");
                if (directive.UnsafeInline) csp.Add("'unsafe-inline'");
                if (directive.UnsafeEval) csp.Add("'unsafe-eval'");
                if (directive.StrictDynamic) csp.Add("'strict-dynamic'");

                csp.AddRange(directive.Items.Where(x => x.CspDirectiveItemTypeId == 1).Select(source => source.Content));
                csp.AddRange(directive.Items.Where(x => x.CspDirectiveItemTypeId == 2).Select(hash => $"'{hash.Content}'"));

                csp.Add(";");
            }

            return string.Join(" ", csp).Replace(" ;", ";");
        }
    }
}