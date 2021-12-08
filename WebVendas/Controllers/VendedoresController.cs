using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebVendas.Models;
using WebVendas.Models.ViewModels;
using WebVendas.Services;
using WebVendas.Services.Exceptions;

namespace WebVendas.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly ServicoDeVendas _servicoDeVendas;
        private readonly ServicoDeDepartamento _servicoDeDepartamento;


        public VendedoresController(ServicoDeVendas servicoDeVendas, ServicoDeDepartamento servicoDeDepartamento)
        {
            _servicoDeVendas = servicoDeVendas;
            _servicoDeDepartamento = servicoDeDepartamento;
        }

        //lista todos os vendedores
        public async Task<IActionResult> Index()
        {
            var list = await _servicoDeVendas.FindAllAsync();
            return View(list);
        }

        //cria novo vendedor
        public async Task<IActionResult> Create()
        {
            var departamentos = await _servicoDeDepartamento.FindAllAsync();
            var viewlModel = new VendedorFormViewModel { Departamentos = departamentos };
            return View(viewlModel);
        }

        //Add novo vendedor no banco de dados
        [HttpPost]      //indica que é um metodo POST
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departaments = await _servicoDeDepartamento.FindAllAsync();
                var ViewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departaments };
                return View(ViewModel);
            }
            await _servicoDeVendas.InsertAsync(vendedor);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não foi fornecido." });
            }
            var obj = await _servicoDeVendas.FindByIDAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não encontrado." });
            }
            return View(obj);
        }

        //Vendedor/Deletar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _servicoDeVendas.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não foi fornecido." });
            }
            var obj = await _servicoDeVendas.FindByIDAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não encontrado." });
            }
            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id, Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departaments = await _servicoDeDepartamento.FindAllAsync();
                var ViewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departaments };
                return View(ViewModel);
            }

            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não foi fornecido." });
            }

            var obj = await _servicoDeVendas.FindByIDAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não encontrado." });
            }

            List<Departamento> departamentos = await _servicoDeDepartamento.FindAllAsync();
            VendedorFormViewModel viewModel = new VendedorFormViewModel
            { Vendedor = obj, Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vendedor vendedor)
        {
            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "ID's não correspondem." });
            }
            try
            {
                await _servicoDeVendas.UpdateAsync(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException except)
            {
                return RedirectToAction(nameof(Error), new { message = except.Message });
            }
            catch (DbConcurrencyException except)
            {
                return RedirectToAction(nameof(Error), new { message = except.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }



    }
}
