using System;

namespace WebVendas.Services.Exceptions
{
    public class IntegrityException : ApplicationException
    {
        public  IntegrityException(string message) : base(message)
        {
        }
    }
}
