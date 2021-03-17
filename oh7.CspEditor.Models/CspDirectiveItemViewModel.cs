using System.Collections.Generic;

namespace oh7.CspEditor.Models
{
    public class CspDirectiveItemViewModel
    {
        public CspDirectiveItemType Type { get; set; }
        public List<CspDirectiveItem> Items { get; set; }
        public int ProjectId { get; set; }
        public int DirectiveId { get; set; }
    }
}