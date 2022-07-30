using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using IdoApi.Models;

namespace IdoApi.Models
{
    public class IdoContext : DbContext
    {
        public IdoContext(DbContextOptions<IdoContext> options)
            : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; } = null!;

        public DbSet<IdoApi.Models.StateModel>? State { get; set; }

        public DbSet<IdoApi.Models.ImportanceModel>? ImportanceModel { get; set; }

        public DbSet<IdoApi.Models.CardModel>? CardModel { get; set; }
    }
}