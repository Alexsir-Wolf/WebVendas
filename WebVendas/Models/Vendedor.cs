﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebVendas.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Data de Nascimento")] //customiza display
        [DataType(DataType.Date)] //customiza data
        public DateTime DataNascimento { get; set; }

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
