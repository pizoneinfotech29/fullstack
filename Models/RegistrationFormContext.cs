using fullStackTask.Models;
using Microsoft.EntityFrameworkCore;
namespace FullStackTask.Models

{
    public class RegistrationFormContext : DbContext
    {
        public RegistrationFormContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<RegistrationForm> registrationForm { get; set; }

    }
}
