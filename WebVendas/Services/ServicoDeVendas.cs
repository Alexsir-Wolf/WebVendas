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

        //busca vendedor pelo ID
        public Vendedor FindByID(int id)
        {
            return _context.Vendedor.FirstOrDefault(obj => obj.Id == id);
        }

        //remove vendedor
        public void Remove(int id)
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            _context.SaveChanges();
        }



 


    }
}
