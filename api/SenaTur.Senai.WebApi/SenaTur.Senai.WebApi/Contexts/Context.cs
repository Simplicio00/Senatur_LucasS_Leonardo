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
            //optionsBuilder.UseSqlServer("Server=LUCASSOLIVEIRA\\SQLEXPRESS; Database=SenaTur_Senai_Manha; integrated security=true;");
           // optionsBuilder.UseSqlServer("Server=DEV101\\SQLEXPRESS; Database=SenaTur_Senai_Manha; user Id=sa; pwd=sa@132;");
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
                    IdTipoUsuario = 1
                },
                new Usuarios
                {
                    IdUsuario = 2,
                    Email = "cliente@cliente.com",
                    Senha = "cliente",
                    IdTipoUsuario = 2
                });

            modelBuilder.Entity<Pacotes>().HasData(
                new Pacotes
                {
                    IdPacote = 1,
                    NomePacote = "Salvador - 5 Dias/4 Diárias",
                    Descricao = " O que não falta em Salvador são atrações. Prova disso são as praias, os museus e as construções seculares que dão um charme mais que especial à região. A cidade, sinônimo de alegria, também é conhecida pela efervescência cultural que a credenciou como um dos destinos mais procurados por turistas brasileiros e estrangeiros. O Pelourinho e o Elevador são alguns dos principais pontos de visitação.",
                    DataIda = Convert.ToDateTime("06/08/2020"),
                    DataVolta = Convert.ToDateTime("10/08/2020"),
                    Valor =  Convert.ToDecimal("854.00"),
                    NomeCidade = "Salvador",
                    Ativo = Convert.ToBoolean(1)
},
                new Pacotes
                {
                    IdPacote = 2,
                    NomePacote = "Resorts na Bahia - Litoral Norte - 5 dias/4 diárias",
                    Descricao = "O Litoral Norte da Bahia conta com inúmeras praias emolduradas por coqueiros, além de piscinas naturais de águas mornas que são protegidas por recifes e habitadas por peixes coloridos. Banhos de mar em águas calmas ou agitadas, mergulho com snorkel, caminhada pela orla e calçadões, passeios de bicicleta, pontos turísticos históricos, interação com animais e até baladas estão entre as atrações da região. Destacam-se as praias de Guarajuba, Imbassaí, Praia do Forte e Costa do Sauipe.",
                    DataIda = Convert.ToDateTime("14/05/2020"),
                    DataVolta = Convert.ToDateTime("18/05/2020"),
                    Valor = Convert.ToDecimal("1826.00"),
                    NomeCidade = "Salvador",
                    Ativo = Convert.ToBoolean(1)
                },
                new Pacotes
                {
                    IdPacote = 3,
                    NomePacote = "Bonito via Campo Grande - 1 Passeio - 5 dias/4 diárias",
                    Descricao = "Localizado no estado de Mato Grosso do Sul e ao sul do Pantanal, Bonito possui centenas de cachoeiras, rios e lagos de águas cristalinas, além de cavernas inundadas, paredões rochosos e uma infinidade de peixes. Os aventureiros costumam render-se facilmente a esse destino regado por trilhas ecológicas, passeios de bote e descidas de rapel pelas inúmeras quedas d'água da região",
                    DataIda = Convert.ToDateTime("28/03/2020"),
                    DataVolta = Convert.ToDateTime("01/04/2020"),
                    Valor = Convert.ToDecimal("1004.00"),
                    NomeCidade = "Bonito",
                    Ativo = Convert.ToBoolean(1)
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
