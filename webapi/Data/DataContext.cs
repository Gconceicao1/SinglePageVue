using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options) { }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Professor>()
            .HasData(
                new List<Professor>(){

                new Professor(){
                Id = 1,
                Nome = "Gabriel",
                SobreNome = "de Moraes Domingues Conceição",
                Materia = "Front-End"
                },
                new Professor(){
                Id = 2,
                Nome = "Jorge",
                SobreNome = "Benjor",
                Materia = "Fundamentos da MPB"
                },
                new Professor(){
                Id = 3,
                Nome = "Jimmi",
                SobreNome = "Hendrix",
                Materia = "Guitarra"
                },

                }
            );
            builder.Entity<Aluno>()
            .HasData(
                new List<Aluno>(){

                new Aluno(){
                Id = 1,
                Nome = "Rodolfo",
                SobreNome = "Santos",
                DataNasc = "01/01/2020",
                ProfessorId = 1
                },
                new Aluno(){
                Id = 2,
                Nome = "Camila",
                SobreNome = "Teixeira",
                DataNasc = "01/01/2020",
                ProfessorId = 2
                },
                new Aluno(){
                Id = 3,
                Nome = "Yuri",
                SobreNome = "Mizuno",
                DataNasc = "01/01/2020",
                ProfessorId = 3
                },

                }
            );
        }
    }
}