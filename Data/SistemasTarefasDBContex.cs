using desafio.Data.Map;
using desafio.models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace desafio.Data
{
    public class SistemasTarefasDBContex : DbContext
    {
        public SistemasTarefasDBContex(DbContextOptions<SistemasTarefasDBContex> options)
            : base(options) 
        {
        } 
    public DbSet<UsuarioModel>  Usuarios { get; set; }  
    public DbSet<TarefaModel> Tarefas    { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());




            base.OnModelCreating(modelBuilder); 
        }
    }
}
