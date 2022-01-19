using System;
//using System.Configuration;
using System.IO;
using Entities;
using Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Interface;
using Service.Services;
using Service;

namespace WT_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
                var serviceCollection = new ServiceCollection();
                ConfigureServices(serviceCollection);
                var serviceProvider = serviceCollection.BuildServiceProvider();
                serviceProvider.GetService<Run>().UpdateProfile();
                serviceProvider.GetService<Run>().LeaveApplication();
                serviceProvider.GetService<Run>().LeaveApporval();
                serviceProvider.GetService<Run>().ChangeNotificatonPreferance();
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                var a = ex.Message;
            }
           
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appSettings.json", false).Build();

            services.AddSingleton<IConfiguration>(configuration);
            services.AddOptions();
            //services.Configure<AppSettings>(configuration.GetSection("Configuration"));
            services.AddDbContext<TestDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnStr")));
            services.AddScoped<IEmployeeService, EmployeeService>()
             
               .AddScoped<ILeaveService, LeaveService>()
               .AddScoped<INotificationSettingService, NotificationSettingService>()
               .AddScoped<IUserService, UserService>()
             
              
               .AddScoped<INotificationPreferanceService, NotificationPreferanceService>()
                .AddScoped<Run>(); ;
        }
      
    }
    public class Run
    {
        private readonly IEmployeeService _employeeService;
        private readonly TestDbContext _dbContext;

        private readonly ILeaveService _leaveService;
        private readonly IUserService _userService;
        private readonly INotificationPreferanceService _notificationPreferance;
        private INotificationSettingService _notificationSetting;
        public Run(IEmployeeService employeeService, TestDbContext dbContext,INotificationSettingService notificationSetting,
            ILeaveService leaveService, IUserService userService, INotificationPreferanceService notificationPreferance)
        {
            _notificationPreferance = notificationPreferance;
            _employeeService = employeeService;
            _dbContext = dbContext;
            _notificationSetting = notificationSetting;
            _leaveService = leaveService;
            _userService = userService;
        }
        public void UpdateProfile()
        {
            try
            {

                var emp = new Employee
                {
                    Id = 1,
                    FirstName = "faisal",
                    LastName = "Ahmed",
                    PhoneNumber = "01628300434",
                    Email = "a@email.com",
                    ManagerId = 0,
                    UserId = 1

                };
                var updated = _employeeService.Update(emp);
                
                if (updated == 1)
                {
                    _notificationSetting.ProfileUpdateNotification(emp.Id);
                  
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void LeaveApplication()
        {
            try
            {
                var leave = new Leave
                {

                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today,
                    StatusEnumId = 0,
                    UserId = 1,
                };

                var created = _leaveService.Create(leave);

                if (created == 1)
                {
                    _notificationSetting.LeaveApplicationNotification(leave.Id);

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void LeaveApporval()
        {
            try
            {
                var leave = new Leave
                {
                    Id = 8,
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today,
                    StatusEnumId = 2,
                    UserId = 1,
                };
                var updated = _leaveService.Update(leave);
                if (updated == 1)
                {
                    _notificationSetting.LeaveApprovalNotification(leave.Id);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void ChangeNotificatonPreferance()
        {
            try
            {
                var notificationPreferance = new NotificationPreferenceByEmployee
                {
                    Id = 4,
                    NotificationTypeEnumId = 1,
                    UserId = 2
                };
                var updated = _notificationPreferance.Update(notificationPreferance);
                if (updated == 1)
                {
                    var emp = _employeeService.GetByUserId(notificationPreferance.UserId);
                    _notificationSetting.ProfileUpdateNotification(emp.Id);

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
