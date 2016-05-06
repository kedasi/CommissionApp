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
    public class ArtExampleTagRepository : EFRepository<ArtExampleTag>, IArtExampleTagRepository
    {
        public ArtExampleTagRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
