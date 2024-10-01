using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Text.Application.Interfaces;
using Text.Domain.Entities;
using Text.Infrastructure.Data;

namespace Text.Controllers
{
    public class ProductsController : Controller
    {
        private readonly TestDBContext _context;
        private readonly IProductRepository _productRepository;

        public ProductsController(TestDBContext context, IProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
        }
        //Get: Products

        public async Task<IActionResult> Index()
        {
            return View(await _productRepository.GetProductsAsync());
        }

        //Get: Products/Details
        public async Task<IActionResult> Details(int id)
        {
            return View(await _productRepository.GetProductByIdAsync(id));
        }


        //GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.AddProductAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        //GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Product product = await _productRepository.GetProductByIdAsync(id);
            return View(product);
        }

        //POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Price")] Product product)
        {
            if (id != product.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _productRepository.UpdateProductAsync(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(id))
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        private bool ProductExists(int id)
        {
            return _context.Products.Any(x => x.ID == id);
        }

        //GET: Products/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _productRepository.GetProductByIdAsync(id));
        }

        //POST: Products/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productRepository.DeleteProductAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
