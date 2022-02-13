using System;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _service.GetProductsAsync();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                await _service.SaveAsync(product);
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id is null)
                return RedirectToAction(nameof(Index));

            return View("~/Views/Product/Create.cshtml", await _service.FindByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> Details(long? id)
        {
            if (id is null)
                return RedirectToAction(nameof(Index));

            return View(await _service.FindByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id is null)
                return RedirectToAction(nameof(Index));

            await _service.DeleteByIdAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
