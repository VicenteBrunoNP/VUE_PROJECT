using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using project_school_API.Models;

namespace project_school_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Professor>()
            .HasData(
                new List<Professor>()
                {
                    new Professor{
                        Id = 1,
                        Nome = "Vicente"
                    },
                    new Professor{
                        Id = 2,
                        Nome = "Paula"
                    },
                    new Professor{
                        Id = 3,
                        Nome = "Luna"
                    }
                }

            );

            builder.Entity<Aluno>()
            .HasData(
                new List<Aluno>()
                {
                    new Aluno{
                        Id = 1,
                        Nome = "Maria",
                        Sobrenome = "Alborraz",
                        DataNasc = "16/10/2000",
                        ProfessorId = 1
                    },
                    new Aluno{
                        Id = 2,
                        Nome = "João",
                        Sobrenome = "Canela",
                        DataNasc = "20/11/2015",
                        ProfessorId = 2
                    },
                    new Aluno{
                        Id = 3,
                        Nome = "Alex",
                        Sobrenome = "Ferreira",
                        DataNasc = "01/01/2001",
                        ProfessorId = 2
                    }
                }

            );
        }
    }
}