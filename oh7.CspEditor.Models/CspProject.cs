using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace oh7.CspEditor.Models
{
    public class CspProject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerId { get; set; }

        [DataType(DataType.MultilineText)] public string Description { get; set; }

        public IList<CspDirective> CspDirectives { get; set; }

    }
}