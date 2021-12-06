﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public IActionResult Index()
        {
            var list = _servicoDeVendas.FindAll();
            return View(list);
        }

        //cria novo vendedor
        public IActionResult Create()
        {
            var departamentos = _servicoDeDepartamento.FindAll();
            var viewlModel = new VendedorFormViewModel { Departamentos = departamentos };
            return View(viewlModel);
        }

        //Add novo vendedor no banco de dados
        [HttpPost]      //indica que é um metodo POST
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            _servicoDeVendas.Insert(vendedor);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _servicoDeVendas.FindByID(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //Vendedor/Deletar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _servicoDeVendas.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _servicoDeVendas.FindByID(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _servicoDeVendas.FindByID(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            List<Departamento> departamentos = _servicoDeDepartamento.FindAll();
            VendedorFormViewModel viewModel = new VendedorFormViewModel
            { Vendedor = obj, Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendedor vendedor)
        {
            if(id != vendedor.Id)
            {
                return BadRequest();
            }
            try
            {
                _servicoDeVendas.Update(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }

    }
}
