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
    public class NotificationPreferanceService : INotificationPreferanceService
    {
        public readonly TestDbContext _dbContext;
        public NotificationPreferanceService(TestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(NotificationPreferenceByEmployee notificationPreference)
        {
            
                _dbContext.NotificationPreferenceByEmployee.Add(notificationPreference);
                return _dbContext.SaveChanges();
            
        }

        public NotificationPreferenceByEmployee Get(long id)
        {
            return _dbContext.NotificationPreferenceByEmployee.Find(id);
        }

        public List<NotificationPreferenceByEmployee> GetByUserId(long userId)
        {
            return _dbContext.NotificationPreferenceByEmployee.Where(x => x.UserId == userId).ToList();
        }

        public int Update(NotificationPreferenceByEmployee notificationPreference)
        {
           
                _dbContext.Entry(notificationPreference).State = EntityState.Modified;
                return  _dbContext.SaveChanges();
           
        }
    }
}
