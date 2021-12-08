using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendas.Data;
using WebVendas.Models;

namespace WebVendas.Services
{
    public class ServicoDeVendasService
    {
        private readonly WebVendasContext _context;

        public ServicoDeVendasService(WebVendasContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroDeVendas>> FindByDateAsync(DateTime? dataMin, DateTime? dataMax)
        {
            var resultado = from obj in _context.RegistroDeVendas select obj;
            if (dataMin.HasValue)
            {
                resultado = resultado.Where(x => x.Data >= dataMin.Value);
            }
            if (dataMax.HasValue)
            {
                resultado = resultado.Where(x => x.Data <= dataMax.Value);
            }
            return await resultado
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Data)
                .ToListAsync();
        }
    }
}
