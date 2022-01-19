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
    public class LeaveService : ILeaveService
    {
        public readonly TestDbContext _dbContext;
        public LeaveService(TestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public  int Create(Leave leave)
        {
            
            _dbContext.Leave.Add(leave);
            return  _dbContext.SaveChanges();
           
        }

        public Leave Get(long id)
        {
            return _dbContext.Leave.Find(id);
        }

        public List<Leave> Get()
        {
            return _dbContext.Leave.ToList();
        }

        public List<Leave> GetByUserId(long userId)
        {
            return _dbContext.Leave.Where(x => x.UserId == userId).ToList();
        }

        public int Update(Leave leave)
        {
            var _leave = _dbContext.Leave.SingleOrDefault(x=>x.Id==leave.Id);
            if (leave != null)
            {
                _leave.StatusEnumId = leave.StatusEnumId;
                _leave.EndDate = leave.EndDate;
                _leave.StartDate = leave.StartDate;
                _leave.UserId = leave.UserId;
                return _dbContext.SaveChanges();
            }
            return 0;
            
        }
    }
}
