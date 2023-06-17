using Microsoft.EntityFrameworkCore;

namespace RecruitmentTasksAH.FirstTask.Model
{
    public class EntrepreneurDbContext : DbContext
    {
        public DbSet<Entrepreneur> Entrepreneurs { get; set; }
        public DbSet<Representative> Representatives { get; set; }

        public EntrepreneurDbContext(DbContextOptions<EntrepreneurDbContext> options) : base(options) { }
    }
}
