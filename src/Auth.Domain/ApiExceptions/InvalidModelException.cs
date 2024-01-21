using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.ApiExceptions
{
    public class InvalidModelException : ApiExceptionBase
    {
        public override HttpStatusCode StatusCode { get => HttpStatusCode.BadRequest; }

        public InvalidModelException() 
            : base("model is invalid")
        {
        }
    }
}
