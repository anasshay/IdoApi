using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace IdoApi.Models
{
    public class IdoContext : DbContext
    {
        public IdoContext(DbContextOptions<IdoContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
    }
}