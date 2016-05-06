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
    public class ArtMessageRepository : EFRepository<ArtMessage>, IArtMessageRepository
    {
        public ArtMessageRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
