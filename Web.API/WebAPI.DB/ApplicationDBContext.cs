using Microsoft.EntityFrameworkCore;
using Web.API.Models;

namespace Web.API.WebAPI.DB
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) {

        }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<ApiAccessModel> ApiAccess { get; set; } 
    }
}
