using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendas.Data;
using WebVendas.Models;

namespace WebVendas.Services
{
    public class ServicoDeVendas
    {
        private readonly WebVendasContext _context;

        public ServicoDeVendas(WebVendasContext context)
        {
            _context = context;
        }
        public List<Vendedor> FindAll()
        {
            return _context.Vendedor.ToList();
        }
 


    }
}
