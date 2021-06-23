using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Exceptions
{
    public class InvalidRowsException : Exception
    {
        public InvalidRowsException(string message) : base(message) { }
    } 
}
