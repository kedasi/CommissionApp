using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class UserFeedback
    {
        public int UserFeedbackId { get; set; }
        public int Stars { get; set; }
        [MaxLength(5000)]
        public string Comment { get; set; }

        //Välisvõtmed
        public int UserId { get; set; }
        public virtual User User { get; set; }


    }
}
