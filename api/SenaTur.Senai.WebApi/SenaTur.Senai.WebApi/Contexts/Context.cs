using Microsoft.EntityFrameworkCore;
using SenaTur.Senai.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaTur.Senai.WebApi.Contexts
{
    public class Context : DbContext
    {
        public DbSet<TiposUsuario> TiposUsuario { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<Pacotes> Pacotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=N-1S-DEV-14\\SQLEXPRESS; Database=SenaTur_Senai_Manha; user Id=sa; pwd=sa@132;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TiposUsuario>(entity =>
            {
                entity
                .HasIndex(tu => tu.Titulo)
                .IsUnique();
                entity.HasData(
                    new Domains.TiposUsuario
                    {
                        IdTipoUsuario = 1,
                        Titulo = "Administrador"
                    },
                    new TiposUsuario
                    {
                        IdTipoUsuario = 2,
                        Titulo = "Cliente"
                    });
            });

            modelBuilder.Entity<Usuarios>().HasData(
                new Usuarios
                {
                    IdUsuario = 1,
                    Email = "admin@admim.com",
                    Senha = "admin",
                    Id
                })
        }
    }
}
