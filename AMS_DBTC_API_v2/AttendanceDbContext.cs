using Microsoft.EntityFrameworkCore;
using AMS_DBTC_API_v2.Models;

namespace AMS_DBTC_API_v2
{
    public class AttendanceDbContext : DbContext
    {
        public AttendanceDbContext(DbContextOptions<AttendanceDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }

}
