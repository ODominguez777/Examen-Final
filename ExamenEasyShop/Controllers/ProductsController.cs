using ExamenEasyShop.CommandHandler;
using ExamenEasyShop.Commands;
using ExamenEasyShop.Configuration;
using ExamenEasyShop.Data;
using ExamenEasyShop.DTOs;
using ExamenEasyShop.Models;
using ExamenEasyShop.QueryHandler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ExamenEasyShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ExamenEasyShopContext _context;
        private readonly ICommandHandler<ProductDTO> _productCommandHandler;
        private readonly ICommandHandler<Product> _updateCommandHandler;
        private readonly ICommandHandler<RemoveByIdCommand> _removeCommandHandler;
        private readonly IQueryHandler<Product, QueryByIdCommand> _productQueryHandler;
        public ProductsController(
            ExamenEasyShopContext context,
            IUnitOfWork unitOfWork,
            ICommandHandler<Product> updateCommandHandler,
            ICommandHandler<ProductDTO> productCommandHandler,
            ICommandHandler<RemoveByIdCommand> removeCommandHandler,
            IQueryHandler<Product, QueryByIdCommand> productQueryHandler)
        {
            _updateCommandHandler = updateCommandHandler;
            _context = context;
            _productCommandHandler = productCommandHandler;
            _removeCommandHandler = removeCommandHandler;
            _productQueryHandler = productQueryHandler;
        }

        // GET: Products
        public async Task<ActionResult<IEnumerable<Product>>> Index()
        {

            return View(await _productQueryHandler.GetAll());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {


            var product = await _productQueryHandler.GetOne(new QueryByIdCommand()
            {
                Id = id
            });
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "NameCategory");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryId,ProductName,ProductDescription,Price,CountInStock,ImageURL,Rating")] ProductDTO product)
        {

            _productCommandHandler.Execute(product);
            return RedirectToAction(nameof(Index));



        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {


            var product = await _productQueryHandler.GetOne(new QueryByIdCommand()
            {
                Id = id
            }); 
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "NameCategory", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryId,ProductName,ProductDescription,Price,CountInStock,ImageURL,Rating")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }


            try
            {
                _updateCommandHandler.Execute(product);
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {


            var product = await _productQueryHandler.GetOne(new QueryByIdCommand() { Id = id });
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            _removeCommandHandler.Execute(new RemoveByIdCommand()
            {
                Id = id
            });

            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {

            return _productQueryHandler.GetOne(new QueryByIdCommand() { Id = id }) != null;
        }
    }
}
