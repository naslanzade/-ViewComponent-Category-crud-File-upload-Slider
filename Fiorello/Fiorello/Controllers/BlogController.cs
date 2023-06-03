using Fiorello.Data;
using Fiorello.Models;
using Fiorello.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Controllers
{
    public class BlogController : Controller
    {


        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {

            if (id is null) return BadRequest();

            Blog blog = await _context.Blogs.Where(m => !m.SoftDeleted).FirstOrDefaultAsync(x => x.Id == id);

            if (blog is null) return NotFound();

            BlogVM blogVm = new()
            {
                Id = blog.Id,
                Name = blog.Title,
                Description = blog.Description,
                Image=blog.BlogImage              

            };

            return View(blogVm);
        }
    }
}
