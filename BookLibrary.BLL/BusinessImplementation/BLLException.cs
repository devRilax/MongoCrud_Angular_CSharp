using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.BLL.BusinessImplementation
{
    public class BLLException : Exception
    {
        public BLLException() { }
        public BLLException(string message) : base(message) { }
        public BLLException(string message, Exception inner) : base(message, inner) { }
    }
}
