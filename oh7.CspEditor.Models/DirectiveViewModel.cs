using System.Collections.Generic;

namespace oh7.CspEditor.Models
{
    public class DirectiveViewModel
    {
        public CspDirective Directive { get; set; }
        public int ProjectId { get; set; }
        public List<CspDirectiveItemType> ItemTypes { get; set; }
    }
}