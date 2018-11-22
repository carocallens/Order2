using System;
using System.Collections.Generic;
using System.Text;

namespace Order2.Domain.Exceptions
{
    public class InvalidObjectException : ApplicationException
    {
        public InvalidObjectException(string message) : base (message) { } 
    }
}
