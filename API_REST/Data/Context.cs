using API_REST.Models;
using Microsoft.EntityFrameworkCore;

namespace API_REST.Data
{
    public class Context : DbContext
    {
        public DbSet<User> User { get; set; }
        public Context(DbContextOptions<Context> options) : base(options) { }
    }
}
