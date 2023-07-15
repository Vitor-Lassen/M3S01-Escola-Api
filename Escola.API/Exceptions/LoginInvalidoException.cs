using System;

namespace Escola.API.Exceptions
{
    public class LoginInvalidoException: Exception
    {
        public LoginInvalidoException(string message): base(message)
        {
            
        }
    }
}
