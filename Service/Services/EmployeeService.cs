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
    public class EmployeeService:IEmployeeService
    {
        public readonly TestDbContext _dbContext;
        public EmployeeService(TestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Employee Get(long id)
        {            
            return _dbContext.Employee.Find(id);
        }
        public Employee GetByUserId(long userId)
        {
            return _dbContext.Employee.Include(x => x.User).SingleOrDefault(x => x.UserId == userId);
        }
        public List<Employee> Get()
        {
            return _dbContext.Employee.ToList();
        }
        public int Create(Employee employee)
        {
            
           
                _dbContext.Employee.Add(employee);
              return  _dbContext.SaveChanges();
            
        }
        public int Update(Employee employee)
        {
           
                _dbContext.Entry(employee).State = EntityState.Modified;
               return _dbContext.SaveChanges();
           
        }
        
       
    }
}
