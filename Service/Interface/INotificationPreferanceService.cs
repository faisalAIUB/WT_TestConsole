using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Model;

namespace Service.Interface
{
    public interface INotificationPreferanceService
    {
        public NotificationPreferenceByEmployee Get(long id);
        public List<NotificationPreferenceByEmployee> GetByUserId(long userId);
        public int Create(NotificationPreferenceByEmployee notificationPreference);
        public int Update(NotificationPreferenceByEmployee notificationPreference);
    }
}
