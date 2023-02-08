using ExamenEasyShop.Configuration;
using ExamenEasyShop.Data;
using ExamenEasyShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ExamenEasyShop.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ExamenEasyShopContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public OrdersController(ExamenEasyShopContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {

            return View(await _unitOfWork.OrderRepository.GetAllAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int id)
        {


            var order = await _unitOfWork.OrderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "StatusName");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Email");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,StatusId,City,Country,DateCreated,PostalCOde,Address")] Order order)
        {

            _unitOfWork.OrderRepository.Add(order);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));

        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int id)
        {


            var order = await _unitOfWork.OrderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "StatusName", order.StatusId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Email", order.UserId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,StatusId,City,Country,DateCreated,PostalCOde,Address")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }


            try
            {
                _unitOfWork.OrderRepository.Update(order);
                _unitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(order.Id))
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

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int id)
        {


            var order = await _unitOfWork.OrderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Order == null)
            {
                return Problem("Entity set 'ExamenEasyShopContext.Order'  is null.");
            }

            _unitOfWork.OrderRepository.Delete(id);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _unitOfWork.OrderRepository.GetByIdAsync(id) != null;
        }
    }
}
