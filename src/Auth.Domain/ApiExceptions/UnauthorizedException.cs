using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.ApiExceptions
{
    public class UnauthorizedException : ApiExceptionBase
    {
        public override HttpStatusCode StatusCode { get => HttpStatusCode.Forbidden; }

        public UnauthorizedException() : base("Forbidden")
        {

        }
    }
}
