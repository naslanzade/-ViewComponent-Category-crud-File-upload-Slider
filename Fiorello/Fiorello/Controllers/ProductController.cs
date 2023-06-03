using Fiorello.Data;
using Fiorello.Models;
using Fiorello.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Controllers
{
    public class ProductController : Controller
    {

        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {

            if (id is null) return BadRequest();

            Product product = await _context.Products.Include(m => m.Images).Include(m=>m.Category).Where(m => !m.SoftDeleted).FirstOrDefaultAsync(x => x.Id == id);
            
            if (product is null) return NotFound();

            ProductDetailVM productDetailVM = new()
            {
                Id = product.Id,
                Name = product.Name,
                CategoryName=product.Category.Name,
                Price = product.Price,  
                Description = product.Description,
                Images=product.Images.ToList()

            };

            return View(productDetailVM);
        }

    }
}
