using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YaoSun.ApplicationCore.Exceptions
{
    public class ConflictException : System.Exception
    {
        public ConflictException(string message) : base(message)
        {

        }
    }
}
