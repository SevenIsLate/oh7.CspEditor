using System.ComponentModel.DataAnnotations;

namespace oh7.CspEditor.Models
{
    public class CspDirectiveItem
    {
        public int Id { get; set; }

        public string Content { get; set; }

        [DataType(DataType.MultilineText)] public string Description { get; set; }

        public int CspDirectiveItemTypeId { get; set; }
        public CspDirectiveItemType CspDirectiveItemType { get; set; }

        public int? CspDirectiveId { get; set; }
        public CspDirective CspDirective { get; set; }
    }
}