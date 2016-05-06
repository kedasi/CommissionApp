using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class UserType
    {
        public int UserTypeId { get; set; }
        [MaxLength(24)]
        public string UserTypeValue { get; set; }

        //välisvõtmed(list)
        public virtual List<User> Users { get; set; }
    }
}