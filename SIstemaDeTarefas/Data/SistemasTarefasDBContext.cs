using Microsoft.EntityFrameworkCore;
using SIstemaDeTarefas.Data.Map;
using SIstemaDeTarefas.Models;

namespace SIstemaDeTarefas.Data
{
    public class SistemasTarefasDBContext : DbContext 
    {
        public SistemasTarefasDBContext(DbContextOptions<SistemasTarefasDBContext> options) : base(options) 
        {
            
        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
