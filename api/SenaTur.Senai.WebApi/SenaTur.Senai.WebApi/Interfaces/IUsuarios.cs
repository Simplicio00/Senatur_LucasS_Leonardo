using SenaTur.Senai.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaTur.Senai.WebApi.Interfaces
{
    interface IUsuarios
    {
        Usuarios CompararBanco(string Email, string Senha);
    }
}
