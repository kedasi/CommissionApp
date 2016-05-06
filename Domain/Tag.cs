using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Tag
    {
        public int TagId { get; set; }
        [MaxLength(24)]
        public string TagText { get; set; }

        //välisvõtmed
        public virtual List<UserTag> UserTags { get; set; }
        public virtual List<ArtExample> ArtExamples { get; set; }

        public int TagTypeId { get; set; }
        public virtual TagType TagType { get; set; }
    }
}
