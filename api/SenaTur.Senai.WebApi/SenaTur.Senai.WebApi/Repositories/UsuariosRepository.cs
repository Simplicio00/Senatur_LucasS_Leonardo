using Microsoft.EntityFrameworkCore;
using SenaTur.Senai.WebApi.Contexts;
using SenaTur.Senai.WebApi.Domains;
using SenaTur.Senai.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaTur.Senai.WebApi.Repositories
{
    public class UsuariosRepository : IUsuarios
    {
        Context banco = new Context();

        public Usuarios CompararBanco(string Email, string Senha)
        {
            return banco.Usuarios.FirstOrDefault(a => a.Email == Email && a.Senha == Senha);
        }

        public IEnumerable<Usuarios> Listar()
        {
            return banco.Usuarios.Include(a => a.IdTipoUsuarioNavigation).ToList();
        }
    }
}
