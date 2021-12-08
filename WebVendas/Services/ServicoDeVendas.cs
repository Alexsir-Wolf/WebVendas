using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendas.Data;
using WebVendas.Models;
using WebVendas.Services.Exceptions;

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
        public async Task<List<Vendedor>> FindAllAsync()
        {
            return await _context.Vendedor.ToListAsync();
        }

        //ADD novo vendedor no banco de dados
        public async Task InsertAsync(Vendedor obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        //busca vendedor pelo ID
        public async Task<Vendedor> FindByIDAsync(int id)
        {
            return await _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        //remove vendedor
        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Vendedor.FindAsync(id);
                _context.Vendedor.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException dbExcpt) 
            {
                throw new IntegrityException("Você não pode deletar este vendedor porque ele/ela ainda possui vendas.");
            }
        }

        public async Task UpdateAsync(Vendedor obj)
        {
            bool hasAny = await _context.Vendedor.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }




    }
}
