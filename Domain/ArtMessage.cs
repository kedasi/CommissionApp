using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class ArtMessage
    {
        public int ArtMessageId { get; set; }
        [MaxLength(24)]
        public string Title { get; set; }
        [MaxLength(5000)]
        public string ArtMessageText { get; set; }

        //Välisvõtmed

        public int UserMessageId { get; set; }
        public virtual UserMessage UserMessage { get; set; }
        public int ArtExampleId { get; set; }
        public virtual ArtExample ArtExample { get; set; }
    }
}
