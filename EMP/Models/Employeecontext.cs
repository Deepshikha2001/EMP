using Microsoft.EntityFrameworkCore;

namespace EMP.Models
{
    public class Employeecontext : DbContext
    {
      
            public Employeecontext(DbContextOptions<Employeecontext> options) : base(options)
            {

            }

            public DbSet<Employee> Employee { get; set; }
       
    }
}
