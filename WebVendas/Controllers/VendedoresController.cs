using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult Index()
        {
            var list = _servicoDeVendas.FindAll();
            return View(list);
        }
    }
}
