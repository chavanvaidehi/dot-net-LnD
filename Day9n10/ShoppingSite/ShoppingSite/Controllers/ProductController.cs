using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingSite.Data;
using ShoppingSite.Helpers;
using ShoppingSite.Models;

namespace ShoppingSite.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // 🛍️ Show all products
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        // ➕ Add a product to session-based cart
        public IActionResult AddToCart(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            var cart = HttpContext.Session.GetObject<List<CartItem>>("Cart") ?? new List<CartItem>();

            var existingItem = cart.FirstOrDefault(c => c.ProductId == id);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    Quantity = 1
                });
            }

            HttpContext.Session.SetObject("Cart", cart);
            return RedirectToAction("Index");
        }

        // 🛒 View Cart
        public IActionResult Cart()
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>("Cart") ?? new List<CartItem>();
            return View(cart);
        }
        public IActionResult Checkout()
        {
            
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            
            var cart = HttpContext.Session.GetObject<List<CartItem>>("Cart");
            if (cart == null || !cart.Any())
            {
                TempData["Error"] = "Cart is empty!";
                return RedirectToAction("Cart");
            }


            
            var order = new Order
            {
                TotalAmount = cart.Sum(item => item.Price * item.Quantity),
                Items = cart.Select(item => new OrderItem
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    Quantity = item.Quantity
                }).ToList()
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            HttpContext.Session.Remove("Cart");
            TempData["Success"] = "Order placed successfully!";

            return RedirectToAction("OrderSummary", new { id = order.Id });
        }
        public IActionResult OrderSummary(int id)
        {
            var order = _context.Orders
                .Include(o => o.Items)
                .FirstOrDefault(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }


    }
}
