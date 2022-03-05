using Microsoft.EntityFrameworkCore;
using DemoDapperAPI.Models;

namespace DemoDapperAPI.Data
{
    public class DemoDapperAPIContext : DbContext
    {
        public DemoDapperAPIContext (DbContextOptions<DapperAPIContext> options) : base(options)
        {

        }
        public DbSet<DemoDapperAPI.Models.Student> Student { get; set; }
    }
}
