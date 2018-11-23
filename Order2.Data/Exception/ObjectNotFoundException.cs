using System;
using System.Collections.Generic;
using System.Text;

namespace Order2.Data.Exception
{
    public class ObjectNotFoundException : ApplicationException
    {
        public ObjectNotFoundException(string message) : base(message) { }
    }
}
