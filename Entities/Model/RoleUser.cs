using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class RoleUser
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public long UserId { get; set; }
    }
}
