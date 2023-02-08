using ExamenEasyShop.Configuration;
using ExamenEasyShop.Data;
using ExamenEasyShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamenEasyShop.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ExamenEasyShopContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesController(ExamenEasyShopContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: Categories
        public async Task<ActionResult<Category>> Index()
        {
            return View(await _unitOfWork.CategoryRepository.GetAllAsync());
        }

        // GET: Categories/Details/5
        public async Task<ActionResult<Category>> Details(int id)
        {


            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Category>> Create([Bind("Id,NameCategory")] Category category)
        {

            _unitOfWork.CategoryRepository.Add(category);
            _unitOfWork.Commit();

            return RedirectToAction(nameof(Index));


        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Category == null)
            {
                return NotFound();
            }

            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameCategory")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            _unitOfWork.CategoryRepository.Update(category);
            try
            {

                _unitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));



        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Category == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rol == null)
            {
                return Problem("Entity set 'ExamenEasyShopContext.Rol'  is null.");
            }

            _unitOfWork.CategoryRepository.Delete(id);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Category.Any(e => e.Id == id);
        }
    }
}
