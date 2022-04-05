using FirstWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApplication.Data
{
    public class AplicationDb : DbContext
    {
        public AplicationDb(DbContextOptions<AplicationDb> options) : base(options) 
        { 

        }

        public DbSet<CatCorm> catCorms { get; set; }

    }
}
