using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.ApiExceptions
{
    public abstract class ApiExceptionBase :Exception
    {
        public virtual HttpStatusCode StatusCode { get => HttpStatusCode.InternalServerError; }

        protected ApiExceptionBase()
        {
        }

        protected ApiExceptionBase(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ApiExceptionBase(string message) : base(message)
        {

        }
    }
}
