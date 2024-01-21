using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.ApiExceptions
{
    public class NotFoundException : ApiExceptionBase
    {
        public override HttpStatusCode StatusCode { get => HttpStatusCode.NotFound; }

        public NotFoundException() : base("Not Found")
        {
        }
        public NotFoundException(string message) : base(message)
        {
        }

        public static void ThrowIfNullOrEmpty(object value)
        {
            if (value is null || value.ToString() == string.Empty)
                throw new NotFoundException();
        }
    }
}
