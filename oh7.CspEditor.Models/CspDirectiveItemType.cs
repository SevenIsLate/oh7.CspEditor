using System.Collections.Generic;

namespace oh7.CspEditor.Models
{
    public class CspDirectiveItemType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<CspDirectiveItem> CspDirectiveItems { get; set; }
    }
}