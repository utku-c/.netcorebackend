using Microsoft.EntityFrameworkCore;

namespace ActivitesAndWeather.EfCore
{
    public class EfDataContext : DbContext
    {
        public EfDataContext(DbContextOptions<EfDataContext> options) : base(options) { }
        public DbSet<Activity> Activities { get; set; }
    }
}
