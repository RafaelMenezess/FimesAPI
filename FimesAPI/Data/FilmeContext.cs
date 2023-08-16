using FimesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FimesAPI.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opt) : base(opt)
        {

        }
        public DbSet<Filme> Filmes { get; set; }
    }
}
