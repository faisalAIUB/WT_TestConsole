using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Interface;
using Entities;
using Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace Service.Services
{
    public class UserService : IUserService
    {
        public readonly TestDbContext _dbContext;
        public  UserService(TestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(User user)
        {
          
                _dbContext.User.Add(user);
              return  _dbContext.SaveChanges();
           
        }

        public User Get(long id)
        {
            return _dbContext.User.Include(x=>x.Employee).SingleOrDefault(x=>x.Id==id);
        }

        public List<User> Get()
        {
            return _dbContext.User.Include(x=>x.Employee).ToList();
        }

        public int Update(User user)
        {
           
                _dbContext.Entry(user).State = EntityState.Modified;
              return  _dbContext.SaveChanges();
           
        }
    }
}
