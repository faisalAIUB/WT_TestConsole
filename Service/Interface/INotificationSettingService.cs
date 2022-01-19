using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface INotificationSettingService
    {
        
        public bool LeaveApplicationNotification(long leaveId);
        public bool LeaveApprovalNotification(long leaveId);
        public bool ProfileUpdateNotification(long UserId);
        public bool SendEmail(string subject, string body, string contact,string userName);
        public bool SendSMS(string subject, string body, string contact,string userName);
        public bool SendWebPushNotification(string subject, string body, string contact,string userName);
    }

}
