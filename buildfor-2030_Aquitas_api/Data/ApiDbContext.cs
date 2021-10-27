using buildfor_2030_Aquitas_api.Models;
using Microsoft.EntityFrameworkCore;

namespace buildfor_2030_Aquitas_api.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

    }
}
