using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendas.Models;
using WebVendas.Models.Enums;

namespace WebVendas.Data
{
    public class SeedingService
    {
        private WebVendasContext _context;
            
        public SeedingService(WebVendasContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Departamento.Any() ||
               _context.Vendedor.Any() ||
               _context.RegistroDeVendas.Any())
            {
                return; 
                //banco de dados foi populado
            }

            Departamento d1 = new Departamento(1, "Computadores");
            Departamento d2 = new Departamento(2, "Electronicos");
            Departamento d3 = new Departamento(3, "Fashion");
            Departamento d4 = new Departamento(4, "Livros");

            Vendedor v1 = new Vendedor(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Vendedor v2 = new Vendedor(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, d2);
            Vendedor v3 = new Vendedor(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, d1);
            Vendedor v4 = new Vendedor(4, "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, d4);
            Vendedor v5 = new Vendedor(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, d3);
            Vendedor v6 = new Vendedor(6, "Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0, d2);

            RegistroDeVendas r1 = new RegistroDeVendas(1, new DateTime(2021, 09, 25), 11000, StatusDeVendas.Vendido, v1);
            RegistroDeVendas r2 = new RegistroDeVendas(2, new DateTime(2021, 09, 4), 7000, StatusDeVendas.Vendido, v5);
            RegistroDeVendas r3 = new RegistroDeVendas(3, new DateTime(2021, 09, 13), 4000, StatusDeVendas.Cancelado, v4);
            RegistroDeVendas r4 = new RegistroDeVendas(4, new DateTime(2021, 09, 1), 8000, StatusDeVendas.Vendido, v1);
            RegistroDeVendas r5 = new RegistroDeVendas(5, new DateTime(2021, 09, 21), 3000, StatusDeVendas.Vendido, v3);
            RegistroDeVendas r6 = new RegistroDeVendas(6, new DateTime(2021, 09, 15), 2000, StatusDeVendas.Vendido, v1);
            RegistroDeVendas r7 = new RegistroDeVendas(7, new DateTime(2021, 09, 28), 13000, StatusDeVendas.Vendido, v2);
            RegistroDeVendas r8 = new RegistroDeVendas(8, new DateTime(2021, 09, 11), 4000, StatusDeVendas.Vendido, v4);
            RegistroDeVendas r9 = new RegistroDeVendas(9, new DateTime(2021, 09, 14), 11000, StatusDeVendas.Pendente, v6);
            RegistroDeVendas r10 = new RegistroDeVendas(10, new DateTime(2021, 09, 7), 9000, StatusDeVendas.Vendido, v6);
            RegistroDeVendas r11 = new RegistroDeVendas(11, new DateTime(2021, 09, 13), 6000, StatusDeVendas.Vendido, v2);
            RegistroDeVendas r12 = new RegistroDeVendas(12, new DateTime(2021, 09, 25), 7000, StatusDeVendas.Pendente, v3);
            RegistroDeVendas r13 = new RegistroDeVendas(13, new DateTime(2021, 09, 29), 10000, StatusDeVendas.Vendido, v4);
            RegistroDeVendas r14 = new RegistroDeVendas(14, new DateTime(2021, 09, 4), 3000, StatusDeVendas.Vendido, v5);
            RegistroDeVendas r15 = new RegistroDeVendas(15, new DateTime(2021, 09, 12), 4000, StatusDeVendas.Vendido, v1);
            RegistroDeVendas r16 = new RegistroDeVendas(16, new DateTime(2021, 10, 5), 2000, StatusDeVendas.Vendido, v4);
            RegistroDeVendas r17 = new RegistroDeVendas(17, new DateTime(2021, 10, 1), 12000, StatusDeVendas.Vendido, v1);
            RegistroDeVendas r18 = new RegistroDeVendas(18, new DateTime(2021, 10, 24), 6000, StatusDeVendas.Vendido, v3);
            RegistroDeVendas r19 = new RegistroDeVendas(19, new DateTime(2021, 10, 22), 8000, StatusDeVendas.Vendido, v5);
            RegistroDeVendas r20 = new RegistroDeVendas(20, new DateTime(2021, 10, 15), 8000, StatusDeVendas.Vendido, v6);
            RegistroDeVendas r21 = new RegistroDeVendas(21, new DateTime(2021, 10, 17), 9000, StatusDeVendas.Vendido, v2);
            RegistroDeVendas r22 = new RegistroDeVendas(22, new DateTime(2021, 10, 24), 4000, StatusDeVendas.Vendido, v4);
            RegistroDeVendas r23 = new RegistroDeVendas(23, new DateTime(2021, 10, 19), 11000, StatusDeVendas.Cancelado, v2);
            RegistroDeVendas r24 = new RegistroDeVendas(24, new DateTime(2021, 10, 12), 8000, StatusDeVendas.Vendido, v5);
            RegistroDeVendas r25 = new RegistroDeVendas(25, new DateTime(2021, 10, 31), 7000, StatusDeVendas.Vendido, v3);
            RegistroDeVendas r26 = new RegistroDeVendas(26, new DateTime(2021, 10, 6), 5000, StatusDeVendas.Vendido, v4);
            RegistroDeVendas r27 = new RegistroDeVendas(27, new DateTime(2021, 10, 13), 9000, StatusDeVendas.Pendente, v1);
            RegistroDeVendas r28 = new RegistroDeVendas(28, new DateTime(2021, 10, 7), 4000, StatusDeVendas.Vendido, v3);
            RegistroDeVendas r29 = new RegistroDeVendas(29, new DateTime(2021, 10, 23), 12000, StatusDeVendas.Vendido, v5);
            RegistroDeVendas r30 = new RegistroDeVendas(30, new DateTime(2021, 10, 12), 5000, StatusDeVendas.Vendido, v2);

            _context.Departamento.AddRange(d1, d2, d3, d4);
            //Add departamentos no banco de dados

            _context.Vendedor.AddRange(v1, v2, v3, v4, v5, v6);
            //Add vendedores no banco de dados

            _context.RegistroDeVendas.AddRange(
                r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r25, r26, r27, r28, r29, r30
                //Add vendas no banco de dados
            );

            _context.SaveChanges();
        }
    }
}

