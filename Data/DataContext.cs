using checkpointdotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace checkpointdotnet.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Usuarios { get; set; }
    }
}
