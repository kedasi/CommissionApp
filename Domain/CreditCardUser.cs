using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CreditCardUser
    {
        public int CreditCardUserId { get; set; }

        //Välisvõtmed
        public int CreditCardInfoId { get; set; }
        public virtual CreditCardInfo CreditCardInfo { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
