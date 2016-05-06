using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Picture
    {
        public int PictureId { get; set; }
        [MaxLength(500)]
        public string PictureUrl { get; set; }
        public DateTime PictureDate { get; set; }
        [MaxLength(500)]
        public string PictureComment { get; set; }

        //välisvõtmed
        public virtual List<ArtExample> ArtExamples { get; set; }
        public virtual List<Project> Projects { get; set; }
    }
}
