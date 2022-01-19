using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.Model;

namespace Entities
{
    public class TestDbContext:DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RoleUser> RoleUser { get; set; }
        public DbSet<Leave> Leave { get; set; }
        public DbSet<NotificationPreferenceByEmployee> NotificationPreferenceByEmployee { get; set; }
    }
}
