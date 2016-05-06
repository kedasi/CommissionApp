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
    public class ArtExampleRepository : EFRepository<ArtExample>, IArtExampleRepository
    {
        public ArtExampleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
