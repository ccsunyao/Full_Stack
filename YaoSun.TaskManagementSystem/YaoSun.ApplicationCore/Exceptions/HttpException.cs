using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace YaoSun.ApplicationCore.Exceptions
{
    public class HttpException : System.Exception
    {
        public HttpStatusCode Code { get; }
        public object Errors { get; set; }

        public HttpException(HttpStatusCode code, object errors = null)
        {
            Code = code;
            Errors = errors;
        }
    }
}
