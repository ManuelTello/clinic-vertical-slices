using Microsoft.EntityFrameworkCore;
using NET.Clinic.API.Entities;

namespace NET.Clinic.API.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        
        public DbSet<Appointment> Appointments { get; set; }
    }
}