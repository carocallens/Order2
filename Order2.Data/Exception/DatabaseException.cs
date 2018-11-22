using System;
using System.Collections.Generic;
using System.Text;

namespace Order2.Data.Exception
{
    public class DatabaseException : ApplicationException
    {
        public DatabaseException(string message) : base(message) { }
    }
}
