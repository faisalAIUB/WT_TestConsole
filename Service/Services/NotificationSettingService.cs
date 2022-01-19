using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Interface;
using Entities;
using Entities.Model;
using Microsoft.EntityFrameworkCore;
using static Service.EnumCollection;

namespace Service.Services
{
    public class NotificationSettingService:INotificationSettingService
    {
        public readonly TestDbContext _dbContext;
        public NotificationSettingService(TestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool LeaveApplicationNotification(long leaveId)
        {
            string subject = "Leave Notification";
            string body = "";
            var leave = _dbContext.Leave.Find(leaveId);
            if (leave != null)
            {
                var employee =  _dbContext.Employee.SingleOrDefault(x => x.UserId == leave.UserId);
                if (employee != null)
                {
                    var manager = _dbContext.Employee.Include(x => x.User).SingleOrDefault(x=>x.Id==employee.ManagerId);
                    if (manager != null)
                    {
                        body += employee.FirstName + " " + employee.LastName + " has applied leave from " + leave.StartDate.ToString("dd-MM-yyyy") + " to "
                            + leave.EndDate.ToString("dd-MM-yyyy");
                        var preferanceList = _dbContext.NotificationPreferenceByEmployee.Where(x => x.UserId == manager.UserId);
                        foreach (var item in preferanceList)
                        {
                            if (item.NotificationTypeEnumId == (byte)EnumCollection.NotificationTypeEnum.Email)
                            {
                                SendEmail(subject, body, manager.PhoneNumber, manager.User.UserName);
                            }
                            if (item.NotificationTypeEnumId == (byte)EnumCollection.NotificationTypeEnum.SMS)
                            {
                                SendSMS(subject, body, manager.Email, manager.User.UserName);
                            }
                            if (item.NotificationTypeEnumId == (byte)EnumCollection.NotificationTypeEnum.WebPushNotification)
                            {
                                SendWebPushNotification(subject, body, manager.User.UserName, manager.User.UserName);
                            }
                        }
                       
                        
                    }
                }

            }
            return true;
        }

        public bool LeaveApprovalNotification(long leaveId)
        {
            string subject = "Leave Notification";
            string body = "Your Leave application is  ";
            var leave = _dbContext.Leave.Find(leaveId);
            if (leave != null)
            {
                body += EnumCollection.GetDisplayName((StatusEnum)leave.StatusEnumId);
                var employee = _dbContext.Employee.Include(x=>x.User).SingleOrDefault(x => x.UserId == leave.UserId);
                if (employee != null)
                {
                    var preferanceList = _dbContext.NotificationPreferenceByEmployee.Where(x => x.UserId == employee.UserId);
                    foreach (var item in preferanceList)
                    {
                        if (item.NotificationTypeEnumId == (byte)EnumCollection.NotificationTypeEnum.Email)
                        {
                            SendEmail(subject, body, employee.PhoneNumber, employee.User.UserName);
                        }
                        if (item.NotificationTypeEnumId == (byte)EnumCollection.NotificationTypeEnum.SMS)
                        {
                            SendSMS(subject, body, employee.Email, employee.User.UserName);
                        }
                        if (item.NotificationTypeEnumId == (byte)EnumCollection.NotificationTypeEnum.WebPushNotification)
                        {
                            SendWebPushNotification(subject, body, employee.User.UserName, employee.User.UserName);
                        }
                    }

                }
            }
            return true;
        }

        public bool ProfileUpdateNotification(long UserId)
        {
            string subject = "Profile Update";
            string body = "Profile Updated for ";

            var employee = _dbContext.Employee.Include(x => x.User).SingleOrDefault(x => x.UserId == UserId);
            if (employee != null)
            {
                body = body + employee.FirstName + " " + employee.LastName;
                var preferanceList = _dbContext.NotificationPreferenceByEmployee.Where(x => x.UserId == employee.UserId);
                foreach (var item in preferanceList)
                {
                    if (item.NotificationTypeEnumId == (byte)EnumCollection.NotificationTypeEnum.Email)
                    {
                        SendEmail(subject, body, employee.PhoneNumber, employee.User.UserName);
                    }
                    if (item.NotificationTypeEnumId == (byte)EnumCollection.NotificationTypeEnum.SMS)
                    {
                        SendSMS(subject, body, employee.Email, employee.User.UserName);
                    }
                    if (item.NotificationTypeEnumId == (byte)EnumCollection.NotificationTypeEnum.WebPushNotification)
                    {
                        SendWebPushNotification(subject, body, employee.User.UserName, employee.User.UserName);
                    }
                }

                var manager = _dbContext.Employee.Include(x => x.User).SingleOrDefault(x => x.Id == employee.ManagerId);
                if (manager != null)
                {
                    var mPreferanceList = _dbContext.NotificationPreferenceByEmployee.Where(x => x.UserId == manager.UserId);
                    foreach (var item in mPreferanceList)
                    {
                        if (item.NotificationTypeEnumId == (byte)EnumCollection.NotificationTypeEnum.Email)
                        {
                            SendEmail(subject, body, manager.PhoneNumber, manager.User.UserName);
                        }
                        if (item.NotificationTypeEnumId == (byte)EnumCollection.NotificationTypeEnum.SMS)
                        {
                            SendSMS(subject, body, manager.Email, manager.User.UserName);
                        }
                        if (item.NotificationTypeEnumId == (byte)EnumCollection.NotificationTypeEnum.WebPushNotification)
                        {
                            SendWebPushNotification(subject, body, manager.User.UserName, manager.User.UserName);
                        }
                    }

                }
                var role = _dbContext.Role.SingleOrDefault(x => x.Name == "HR Manager");
                if (role != null)
                {
                    var hrs = (from ru in _dbContext.RoleUser
                               where ru.RoleId == role.Id
                               from u in _dbContext.User.Include(x => x.Employee)
                               where u.Id == ru.UserId
                               select u).ToList();
                    foreach (var item in hrs)
                    {
                        var iPreferanceList = _dbContext.NotificationPreferenceByEmployee.Where(x => x.UserId == item.Id);
                        foreach (var iPre in iPreferanceList)
                        {
                            if (iPre.NotificationTypeEnumId == (byte)EnumCollection.NotificationTypeEnum.Email)
                            {
                                SendEmail(subject, body, item.Employee.PhoneNumber, item.UserName);
                            }
                            if (iPre.NotificationTypeEnumId == (byte)EnumCollection.NotificationTypeEnum.SMS)
                            {
                                SendSMS(subject, body, item.Employee.Email, item.UserName);
                            }
                            if (iPre.NotificationTypeEnumId == (byte)EnumCollection.NotificationTypeEnum.WebPushNotification)
                            {
                                SendWebPushNotification(subject, body, item.UserName, item.UserName);
                            }
                        }

                    }
                }
            }

            return true;
        }
       
        public bool SendEmail(string subject, string body, string contact, string userName)
        {
            Console.WriteLine(string.Format("Email is sent to {0}", userName));
            return true;
        }
        public bool SendSMS(string subject, string body, string contact, string userName)
        {
            Console.WriteLine(string.Format("SMS is sent to {0}", userName));
            return true;
        }
        public bool SendWebPushNotification(string subject, string body, string contact, string userName)
        {
            Console.WriteLine(string.Format("Web Push Notification is sent to {0}", userName));
            return true;
        }
    }
}
