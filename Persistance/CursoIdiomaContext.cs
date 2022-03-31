using CursoIdiomas.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CursoIdiomas.API.Persistance
{
    public class CursoIdiomasContext : DbContext
    {
        public CursoIdiomasContext(DbContextOptions<CursoIdiomasContext> options) : base(options)
        {

        }

        public DbSet<Turma> Turmas { get; set;}
        public DbSet<Aluno> Alunos { get; set;}
        public DbSet<Matricula> Matriculas { get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Turma>(e =>{
                e.HasKey(t => t.Id);
                e.HasMany(t => t.Alunos)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);  
                
            });

            builder.Entity<Matricula>(m => {
                m.HasKey(m => m.Id);
                m.HasMany(m => m.Turmas)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Aluno>(a =>{
                a.HasKey(a => a.Id);
                });
           
        }
    }
}