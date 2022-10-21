using Microsoft.EntityFrameworkCore;
using System;
using APIChallenge.Data;

namespace APIChallenge.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options)
        {

        }

        public DbSet<Empregado> Empregados { get; set; }

        public DbSet<Projeto> Projetos { get; set; }

        public DbSet<Membros> Membros { get; set; }
        protected override void OnModelCreating( ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empregado>().HasKey(k => k.id_empregado);
            modelBuilder.Entity<Empregado>().Property(p => p.telefone).HasMaxLength(10);
            modelBuilder.Entity<Empregado>().HasData(
                    new Empregado
                    {
                        id_empregado = 1,
                        primeiro_nome = "Joao",
                        ultimo_nome = "Neto",
                        telefone = 1111111111,
                        endereco = "joaoneivanetos@gmail.com"
                    }
                );

            modelBuilder.Entity<Projeto>().HasKey(k => k.id_projeto);
            modelBuilder.Entity<Projeto>().HasData(
                    new Projeto
                    {
                        id_projeto=1,
                        nome="Leonardo",
                        data_de_criação=DateTime.Now,
                        data_temino = DateTime.Now,
                        gerente = 1,
                    }
                );
            modelBuilder.Entity<Projeto>()
            .HasOne(p => p.empregado)
            .WithMany(b => b.projetos)
            .HasForeignKey(p => p.gerente);

            modelBuilder.Entity<Membros>()
            .HasOne(p => p.empregado)
            .WithMany(b => b.membros)
            .HasForeignKey(p => p.id_empregado);

            modelBuilder.Entity<Membros>()
           .HasOne(p => p.projeto)
           .WithMany(b => b.membros)
           .HasForeignKey(p => p.id_projeto);

            modelBuilder.Entity<Membros>().HasKey(k => k.id_projeto);
            modelBuilder.Entity<Membros>().HasKey(k => k.id_empregado);

          



        }
       
        
           
    }
}
