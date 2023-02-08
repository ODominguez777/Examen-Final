using ExamenEasyShop.Configuration;
using ExamenEasyShop.Data;
using ExamenEasyShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ExamenEasyShop.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly ExamenEasyShopContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public OrderDetailsController(ExamenEasyShopContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: OrderDetails
        public async Task<IActionResult> Index()
        {

            return View(await _unitOfWork.OrderDetailRepository.GetAllAsync());
        }

        // GET: OrderDetails/Details/5
        public async Task<IActionResult> Details(string id)
        {


            var orderDetail = await _unitOfWork.OrderDetailRepository.FindByIds(id);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // GET: OrderDetails/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Address");
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ImageURL");
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,OrderId,ProductName,Quantity,UnitPrice,Subtotal")] OrderDetail orderDetail)
        {

            _unitOfWork.OrderDetailRepository.Add(orderDetail);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));



        }

        // GET: OrderDetails/Edit/5
        public async Task<IActionResult> Edit(string id)
        {

            var orderDetail = await _unitOfWork.OrderDetailRepository.FindByIds(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Address", orderDetail.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ImageURL", orderDetail.ProductId);
            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ProductId,OrderId,ProductName,Quantity,UnitPrice,Subtotal")] OrderDetail orderDetail)
        {

            try
            {
                _unitOfWork.OrderDetailRepository.Update(orderDetail);
                _unitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                string orderDetailIdString = $"{orderDetail.OrderId}-{orderDetail.ProductId}";
                if (!OrderDetailExists(orderDetailIdString))
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

        // GET: OrderDetails/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            var orderDetail = await _unitOfWork.OrderDetailRepository.FindByIds(id);
            if (orderDetail == null)
            {
                Console.WriteLine("E nulo");
                return NotFound();
            }

            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.OrderDetail == null)
            {
                return Problem("Entity set 'ExamenEasyShopContext.OrderDetail'  is null.");
            }

            _unitOfWork.OrderDetailRepository.DeleteByIds(id);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderDetailExists(string id)
        {
            return _unitOfWork.OrderDetailRepository.FindByIds(id) != null;
        }
    }
}
