using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class NotificationPreferenceByEmployee
    {
        public long Id { get; set; }
        public byte NotificationTypeEnumId { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
