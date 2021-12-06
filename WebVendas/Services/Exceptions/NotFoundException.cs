using System;

namespace WebVendas.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        //CONSTRUTOR
        //EXCEÇÃO PERSONALIZADA = NOTFOUND
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
