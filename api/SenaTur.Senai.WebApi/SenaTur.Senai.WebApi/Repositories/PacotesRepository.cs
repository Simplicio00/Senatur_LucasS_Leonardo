using SenaTur.Senai.WebApi.Contexts;
using SenaTur.Senai.WebApi.Domains;
using SenaTur.Senai.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaTur.Senai.WebApi.Repositories
{
    public class PacotesRepository : IPacotesRepository
    {
        Context banco = new Context();

        public Pacotes Atualizar(int id, Pacotes pacoteAtualizado)
        {
            Pacotes atualizado = banco.Pacotes.FirstOrDefault(a => a.IdPacote == id);
            atualizado.NomeCidade = pacoteAtualizado.NomeCidade;
            atualizado.NomePacote = pacoteAtualizado.NomePacote;
            atualizado.Descricao = pacoteAtualizado.Descricao;
            atualizado.DataIda = pacoteAtualizado.DataIda;
            atualizado.DataVolta = pacoteAtualizado.DataVolta;
            atualizado.Valor = pacoteAtualizado.Valor;
            atualizado.Ativo = pacoteAtualizado.Ativo;

            banco.Pacotes.Update(atualizado);
            banco.SaveChanges();
            return atualizado;
        }

        public Pacotes BuscarPorId(int id)
        {
            return banco.Pacotes.FirstOrDefault(a => a.IdPacote == id);
        }

        public void Cadastrar(Pacotes novoPacote)
        {
            banco.Pacotes.Add(novoPacote);

            banco.SaveChanges();
        }

        public List<Pacotes> Listar()
        {
            return banco.Pacotes.ToList();
        }
    }
}
