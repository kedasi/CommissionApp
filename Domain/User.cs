using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public int UserId { get; set; }
        [MaxLength(24)]
        public string Username { get; set; }
        [MaxLength(24)]
        public string Password { get; set; }
        public int Birthdate { get; set; }
        [MaxLength(24)]
        public string Country { get; set; }

        //välisvõti 
        public virtual List<UserFeedback> UserFeedbacks { get; set; }
        public virtual List<CreditCardUser> CreditCardUsers { get; set; }
       public virtual List<UserTag> UserTags { get; set; }
        public virtual List<ArtExample> ArtExamples { get; set; }
        //public virtual List<UserMessage> ToUserMessages { get; set; }
        //public virtual List<UserMessage> FromUserMessages { get; set; }

        public int UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }
    }
}
