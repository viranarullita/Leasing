using Leasing.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace Leasing.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<LeasingInput> LeasingInput { get; set; }
        public DbSet<LeasingResult> LeasingResult { get; set; }
        public DbSet<PVDetail> PVDetail { get; set; }
        public DbSet<NPVChartPoint> NPVChartPoint { get; set; }
        public DbSet<IRRDetail> IRRDetail { get; set; }
    }
}
