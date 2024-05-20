using Microsoft.EntityFrameworkCore;
using refatorando.Data.Map;
using refatorando.Model;

namespace refatorando.Data
{
    public class SistemaDataBaseContext : DbContext
    {
        public SistemaDataBaseContext(DbContextOptions<SistemaDataBaseContext> options) : base(options) { }

        public DbSet<AlunoModel> tbalunos { get; set; }
        public DbSet<EnderecoModel> tbendereco { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
