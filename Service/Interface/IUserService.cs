using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Model;

namespace Service.Interface
{
    public interface IUserService
    {
        public User Get(long id);
        public List<User> Get();
        public int Create(User user);
        public int Update(User user);
    }
}
