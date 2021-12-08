using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<List<Departamento>>FindAllAsync()
        {           //retorna os departamentos ordenados por nome
            return await _context.Departamento.OrderBy(x => x.Nome).ToListAsync();
        }



    }
}
