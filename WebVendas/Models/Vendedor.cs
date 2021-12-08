using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebVendas.Models
{
    public class Vendedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} campo obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres.")]
        public string Nome { get; set; }



        [Required(ErrorMessage = "{0} campo obrigatório")]
        [EmailAddress(ErrorMessage = "Digite um Email válido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "{0} campo obrigatório")]
        [Display(Name = "Data de Nascimento")] //customiza display        
        [DataType(DataType.Date)] //customiza data
        //[Range(typeof(DateTime), "01/01/1966", "31/12/2003", ErrorMessage = "{0} deve estar entre 1/1/1966 e 1/1/2003")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]        
        public DateTime DataNascimento { get; set; }

        
        [Required(ErrorMessage = "{0} campo obrigatório")]
        [Range(100.0, 50000.0, ErrorMessage ="{0} deve conter entre {1} e {2}")]
        [Display(Name = "Salário Base")]
        [DataType(DataType.Currency)]        
        [DisplayFormat(DataFormatString = "{0:F2}")] //somente 2 casas decimais
        public double SalarioBase { get; set; }


        public Departamento Departamento { get; set; }

        [Display(Name ="Departamento")]
        public int DepartamentoId { get; set; }
        public ICollection<RegistroDeVendas> Vendas { get; set; } = new List<RegistroDeVendas>();

        // CONSTRUTORES
        public Vendedor()
        {
        }

        public Vendedor(int id, string nome, string email, DateTime dataNascimento, double salarioBase, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        //METODOS
        public void AddVendas(RegistroDeVendas rv)
        {
            Vendas.Add(rv);
        }

        public void RemoverVendas(RegistroDeVendas rv)
        {
            Vendas.Remove(rv);
        }

        public double TotalDeVendas(DateTime inicial, DateTime final)
        {
            return Vendas.Where(rv => rv.Data >= inicial && rv.Data <= final).Sum(rv => rv.Quantia);
        }       //soma das vendas usando LINQ
    }
}
