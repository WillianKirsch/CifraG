using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestrutura.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(params string[] mensagem)
            : base(string.Concat(string.Join(";", mensagem)))
        { }
    }
}
