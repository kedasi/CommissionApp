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
    public class UserTagRepository : EFRepository<UserTag>, IUserTagRepository
    {
        public UserTagRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
