using System;

namespace WebVendas.Services.Exceptions
{
    public class DbConcurrencyException : ApplicationException
    {
        //CONSTRUTOR
        //As exceções de concurrency ( ) são ativas quando dois usuários
        //tentam alterar os mesmos dados em um banco de dados.
        public DbConcurrencyException(string message) : base(message)
        {
        }
    }
}
