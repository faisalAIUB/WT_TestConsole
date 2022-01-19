using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Model;

namespace Service.Interface
{
    public interface IEmployeeService
    {
        public Employee Get(long id);
        public List<Employee> Get();
        public Employee GetByUserId(long userId);
        public int Create(Employee employee);
        public int Update(Employee employee);
    }
}
