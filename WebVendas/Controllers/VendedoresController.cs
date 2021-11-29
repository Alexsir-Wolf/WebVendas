using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendas.Models;
using WebVendas.Services;

namespace WebVendas.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly ServicoDeVendas _servicoDeVendas;

        public VendedoresController(ServicoDeVendas servicoDeVendas)
        {
            _servicoDeVendas = servicoDeVendas;
        }

        //lista todos os vendedores
        public IActionResult Index()
        {
            var list = _servicoDeVendas.FindAll();
            return View(list);
        }

        //cria novo vendedor
        public IActionResult Create()
        {
            return View();
        }

        //Add novo vendedor no banco de dados
        [HttpPost]      //indica que é um metodo POST
        [ValidateAntiForgeryToken] 
        public IActionResult Create(Vendedor vendedor)
        {
            _servicoDeVendas.Insert(vendedor);
            return RedirectToAction(nameof(Index));

        }




    }
}
