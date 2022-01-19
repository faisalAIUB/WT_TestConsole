using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class Leave
    {
        public long Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte StatusEnumId { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }

}
