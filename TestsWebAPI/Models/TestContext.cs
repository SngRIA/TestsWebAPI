using System.Data.Entity;

namespace TestsWebAPI.Models
{
    public class TestContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}