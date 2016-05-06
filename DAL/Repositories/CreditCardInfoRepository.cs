using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class CreditCardInfoRepository : EFRepository<CreditCardInfo>, ICreditCardInfoRepository
    {
        public CreditCardInfoRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
