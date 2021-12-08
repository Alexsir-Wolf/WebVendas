using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendas.Services;

namespace WebVendas.Controllers
{
    public class RegistroDeVendasController : Controller
    {
        private readonly ServicoDeVendasService _servicoDeVendasService;

        public RegistroDeVendasController(ServicoDeVendasService servicoDeVendasService)
        {
            _servicoDeVendasService = servicoDeVendasService;
        }


        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> BuscaSimples(DateTime? dataMin, DateTime? dataMax)
        {
            if (!dataMin.HasValue)
            {
                dataMin = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!dataMax.HasValue)
            {
                dataMax = DateTime.Now;
            }

            ViewData["dataMin"] = dataMin.Value.ToString("yyyy-MM-dddd");
            ViewData["dataMax"] = dataMax.Value.ToString("yyyy-MM-dddd");
            var resultado = await _servicoDeVendasService.FindByDateAsync(dataMin, dataMax);
            return View(resultado);
        }
        public async Task<IActionResult> BuscaAgrupada(DateTime? dataMin, DateTime? dataMax)
        {

            if (!dataMin.HasValue)
            {
                dataMin = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!dataMax.HasValue)
            {
                dataMax = DateTime.Now;
            }

            ViewData["dataMin"] = dataMin.Value.ToString("yyyy-MM-dddd");
            ViewData["dataMax"] = dataMax.Value.ToString("yyyy-MM-dddd");
            var resultado = await _servicoDeVendasService.FindByDateGroupingAsync(dataMin, dataMax);
            return View(resultado);
        }
    }
}
