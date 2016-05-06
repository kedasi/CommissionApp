using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ArtExample
    {
        public int ArtExampleId { get; set; }
        [MaxLength(500)]
        public string ArtExampleUrl { get; set; }
        [MaxLength(500)]
        public string ArtExampleComment { get; set; }
        public DateTime ArtExampleDate { get; set; }

        //välisvõtmed

        public virtual List<ArtExampleTag> ArtExampleTags { get; set; }
        public virtual List<ArtMessage> ArtMessages { get; set; }


        public int UserId { get; set; }
        public virtual User User { get; set; }


        public int PictureId { get; set; }
        public virtual Picture Picture { get; set; }
    }
}
