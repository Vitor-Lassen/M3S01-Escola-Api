using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Globalization;

namespace Escola.API.Model
{
    public class Usuario
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string TipoAcesso { get; set; }
       
        public override bool Equals(object obj)
        {
            if (obj is Usuario)
            {
                var usuario = (Usuario)obj;
                return Nome == usuario.Nome && 
                       Senha == usuario.Senha &&
                       TipoAcesso == usuario.TipoAcesso;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Nome, Senha, TipoAcesso);
        }
    }
}
