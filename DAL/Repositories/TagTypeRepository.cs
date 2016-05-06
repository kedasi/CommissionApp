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
    public class TagTypeRepository : EFRepository<TagType>, ITagTypeRepository
    {
        public TagTypeRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
