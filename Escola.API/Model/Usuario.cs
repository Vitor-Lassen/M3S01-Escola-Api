using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Globalization;

namespace Escola.API.Model
{
    public class Usuario
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string TipoAcesso { get; set; }
    }
}
