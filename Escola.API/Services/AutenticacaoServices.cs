using Escola.API.DTO;
using Escola.API.Exceptions;
using Escola.API.Interfaces.Services;
using Escola.API.Model;
using Escola.API.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Escola.API.Services
{
    public class AutenticacaoServices : IAutenticacaoServices
    {
        private readonly string _chaveJwt;
        public AutenticacaoServices( IConfiguration configuration)
        {
            _chaveJwt = configuration.GetSection("jwtTokenChave").Get<string>();
        }

        public string Autenticar(LoginDTO login)
        {
            //Service de usuario obtem usuario pelo login.Usuario 
            var usuario = new Usuario() { Nome = "Vitor", Senha = "ss" };
            //criptografar a senha (usando o utils)

            if (usuario != null) {
                if (Criptografia.CriptografarSenha(login.Senha) == usuario.Senha)// comparar com a senha do usuario 
                    return GerarToken(usuario);
            }

            throw new LoginInvalidoException("Usuario ou senha Inválidos");
        }

        private string GerarToken(Usuario usuario)
        {
 

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_chaveJwt);



            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                  {
                      new Claim(ClaimTypes.Name, usuario.Nome),
                      new Claim("Nome", usuario.Nome),
                      new Claim(ClaimTypes.Role, ""),
                  }),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
