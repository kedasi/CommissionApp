using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
  public  class CreditCardInfo
    {
        public int CreditCardInfoId { get; set; }
        [MaxLength(24)]
        public string FirstName { get; set; }
        [MaxLength(24)]
        public string LastName { get; set; }
        public int CreditCardNumber { get; set; }
        public int SecurityNumber { get; set; }
        public int ExpirationDate { get; set; }

        //välisvõtmed
        public virtual List<CreditCardUser> CreditCardUsers { get; set; }
    }
}
