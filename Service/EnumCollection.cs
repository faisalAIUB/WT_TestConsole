using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class EnumCollection
    {
        public enum NotificationTypeEnum
        {
            Email=0,
            SMS=1,
            [Display(Name = "Web Push Notification")]
            WebPushNotification =2
        }
        public enum StatusEnum
        {
            Pending=0,
            Approved=1,
            Declined=2
        }
        public static IList<EnumInfo> GetEnumList(Type enumType)
        {
            var enums = new List<EnumInfo>();

            if (!enumType.IsEnum)
                return enums;


            enums.AddRange(from object v in Enum.GetValues(enumType)
                           select new EnumInfo()
                           {
                               //EnumType = enumType,
                               Id = (int)v,
                               Name = Enum.GetName(enumType, v)
                           });



            return enums;
        }
        
        public static string GetDisplayName(this Enum enumValue)
        {
            string displayName;
            displayName = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault()
                .GetCustomAttribute<DisplayAttribute>()?
                .GetName();
            if (String.IsNullOrEmpty(displayName))
            {
                displayName = enumValue.ToString();
            }
            return displayName;
        }
    }
    public class EnumInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }


    }
}
