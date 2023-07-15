using Escola.API.DTO;

namespace Escola.API.Interfaces.Services
{
    public interface IAutenticacaoServices
    {
        string Autenticar(LoginDTO login);
    }
}
