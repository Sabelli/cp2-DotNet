using CP2_DotNet.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CP2_DotNet.API.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }


        public DbSet<FilmeEntity> Filme { get; set; }
        public DbSet<AvaliacaoEntity> Avaliacao { get; set; }

    }
}
