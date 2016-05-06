using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ArtExampleTag
    {
        public int ArtExampleTagId { get; set; }

        //Välisvõtmed
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }

        public int ArtExampleId { get; set; }
        public virtual ArtExample ArtExample { get; set; }
    }
}
