using Microsoft.EntityFrameworkCore;
using MemoryBook.Models;

namespace MemoryBook.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<FeedbackMessage> FeedbackMessages { get; set; }

        public DbSet<MemBook> Heroes { get; set; }
    }
}
