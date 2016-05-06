using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class UserMessage
    {
        public int UserMessageId { get; set; }
        [MaxLength(24)]
        public string UserMessageTitle { get; set; }
        [MaxLength(5000)]
        public string UserMessageText { get; set; }

        //välisvõtmed

        //public int UserId { get; set; }
        //[ForeignKey("UserId")]
        //public virtual User ToUser { get; set; }

        //public int UserIdTwo { get; set; }
        //[ForeignKey("UserIdTwo")]
        //public virtual User FromUser { get; set; }

        public virtual List<ArtMessage> ArtMessages { get; set; }

        //??? loop viide
    }
}
