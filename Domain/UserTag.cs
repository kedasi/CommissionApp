using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserTag
    {
        public int UserTagId { get; set; }

        //välisvõtmed
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
