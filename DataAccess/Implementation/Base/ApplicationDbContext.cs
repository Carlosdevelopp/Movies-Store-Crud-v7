using DataAccess.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementation.Base
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public virtual DbSet<Movies> Movies { get; set; }   
        public virtual DbSet<Genres> Genres { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }   

    }
}
