using System.Collections.Generic;

namespace oh7.CspEditor.Models
{
    public class CspDirective
    {
        public CspDirective()
        {
            Items = new List<CspDirectiveItem>();
        }

        public int Id { get; set; }
        public string DirectiveName { get; set; }
        public string DisplayName { get; set; }
        public bool Enabled { get; set; }
        public bool None { get; set; }
        public bool Self { get; set; }
        public bool UnsafeInline { get; set; }
        public bool UnsafeEval { get; set; }
        public bool StrictDynamic { get; set; }
        public int Order { get; set; }

        public int CspProjectId { get; set; }
        public CspProject CspProject { get; set; }

        public ICollection<CspDirectiveItem> Items { get; set; }
    }
}