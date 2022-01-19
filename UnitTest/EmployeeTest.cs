using Entities;
using Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Service.Interface;
using Service.Services;
using System;
using Xunit;


namespace UnitTest
{
    public class EmployeeTest
    {
        private IEmployeeService _employeeService;
        public EmployeeTest()
        {

            var services = new ServiceCollection();
            services.AddDbContext<TestDbContext>(options => options.UseSqlServer("Data Source=.;Initial Catalog=WT_Test;Integrated Security=True;"));
            services.AddScoped<IEmployeeService, EmployeeService>();
            var serviceProvider = services.BuildServiceProvider();

            _employeeService = serviceProvider.GetService<IEmployeeService>();
        }
        [Fact]
        public void TestGet()
        {
            var employe = new Employee
            {
                Id = 1,
                UserId = 1,
                FirstName = "Faisal",
                LastName = "Ahmed",
                PhoneNumber = "01628300434",
                Email = string.Empty,
                ManagerId = 0
            };
            var emp = _employeeService.Get(1);
            Assert.NotNull(emp);
            Assert.Equal(1, emp.UserId);
           
        }
        [Fact]
        public void TestUpdate()
        {
            var employe = new Employee
            {
                Id = 1,
                UserId = 1,
                FirstName = "Faisal",
                LastName = "Islam",
                PhoneNumber = "01628300000",
                Email = string.Empty,
                ManagerId = 0
            };
            var updated= _employeeService.Update(employe);
            Assert.Equal(1, updated);
        }
    }
}
