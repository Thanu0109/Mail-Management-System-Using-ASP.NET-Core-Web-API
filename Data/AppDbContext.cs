using MailManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace MailManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Department_D_BIT_22_0015> Departments { get; set; }
        public DbSet<Mail_D_BIT_22_0015> Mails { get; set; }
    }
}
