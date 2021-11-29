using System.Collections.Generic;
using System.Linq;
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

        //lista todos os vendedores
        public List<Vendedor> FindAll()
        {
            return _context.Vendedor.ToList();
        }

        //ADD novo vendedor no banco de dados
        public void Insert(Vendedor obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }


 


    }
}
