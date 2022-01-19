using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model
{
    public class Employee
    {
        [Key]
        public long Id { get; set; }       
        public  long UserId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String PhoneNumber { get; set; }
        public String Email { get; set; }
        public long ManagerId { get; set; }
        public User User { get; set; }

    }
}
