using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Model;

namespace Service.Interface
{
   public interface ILeaveService
    {
        public Leave Get(long id);
        public List<Leave> Get();
        public List<Leave> GetByUserId(long userId);
        public int Create(Leave leave);
        public int Update(Leave leave);
    }
}
