using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Exceptions
{
    public class InvalidNitrogenBaseException : Exception
    {
        public InvalidNitrogenBaseException(string message) : base(message) { }
    }
}
