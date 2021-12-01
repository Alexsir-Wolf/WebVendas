using System.Collections.Generic;
using System.Linq;
using WebVendas.Data;
using WebVendas.Models;

namespace WebVendas.Services
{
    public class ServicoDeDepartamento
    {
        private readonly WebVendasContext _context;

        public ServicoDeDepartamento(WebVendasContext context)
        {
            _context = context;
        }

        public List<Departamento> FindAll()
        {           //retorna os departamentos ordenados por nome
            return _context.Departamento.OrderBy(x => x.Nome).ToList();
        }



    }
}
