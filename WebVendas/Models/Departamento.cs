using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVendas.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();
        
        //CONSTRUTORES
        public Departamento()
        {
        }

        public Departamento(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        //METODOS
        public void AddVendedor(Vendedor vendedor)
        {
            Vendedores.Add(vendedor);
        }   //ADD vendodor na List<Vendedores>

        public double TotalDeVendas(DateTime inicial, DateTime final)
        {
            return Vendedores.Sum(Vendedor => Vendedor.TotalDeVendas(inicial, final));
        }      //soma total de vendas, pegando todos venderor da List<Vendedores>




    }
}
