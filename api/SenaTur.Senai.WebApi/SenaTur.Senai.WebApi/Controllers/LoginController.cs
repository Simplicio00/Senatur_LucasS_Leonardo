using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SenaTur.Senai.WebApi.Domains;
using SenaTur.Senai.WebApi.Repositories;

namespace SenaTur.Senai.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        UsuariosRepository banco = new UsuariosRepository();


        /// <summary>
        /// Gera o token de acesso para um usuário cadastrado
        /// </summary>
        /// <param name="validacao">Email e senha do usuário que será comparada aos do banco</param>
        /// <returns>Retorna um hash sha256 criptografado</returns>
        [HttpPost]
        public IActionResult Autenticar(Usuarios validacao)
        {
           Usuarios usuario = banco.CompararBanco(validacao.Email, validacao.Senha);

            if (usuario != null)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuario.IdTipoUsuario.ToString())
                };
                
                var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("0d13199c64d04f59d9e56a68f1844d09"));
                var credencial = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "SenaTur.Senai.WebApi",
                    audience: "SenaTur.Senai.WebApi",
                    claims:claims,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: credencial
                    );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token)});
            }
            else
            {
                var mensagemErro = "Dados inválidos";
                return NotFound(mensagemErro);
            }
        }
    }
}