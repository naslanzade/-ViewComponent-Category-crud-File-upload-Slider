
using Fiorello.Data;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Fiorello.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Fiorello.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IProductService _productService;


        public HomeController(AppDbContext context,IProductService productService)
        {
            _context = context;
            _productService = productService;
        }


        public async Task<IActionResult> Index()
        {
            
            IEnumerable<Blog> blog = await _context.Blogs.Where(m => !m.SoftDeleted).Take(3).ToListAsync();
            BlogDetail blogDetail = await _context.BlogsDetails.Where(m => !m.SoftDeleted).FirstOrDefaultAsync();
            IEnumerable<Category> categories = await _context.Categories.Where(m => !m.SoftDeleted).ToListAsync();
            IEnumerable<Product> products=await _productService.GetAllAsync();
            About about = await _context.Abouts.Where(m => !m.SoftDeleted).FirstOrDefaultAsync();
            IEnumerable<Expert>  experts= await _context.Experts.Where(m => !m.SoftDeleted).Take(4).ToListAsync();
            IEnumerable<Start> starts = await _context.Starts.Where(m => !m.SoftDeleted).Take(2).ToListAsync();
            IEnumerable<Instagram> instagrams = await _context.Instagrams.Where(m => !m.SoftDeleted).ToListAsync();

            HomeVM homeVM = new() 
            { 
            
              
                Blogs= blog,
                BlogDetail = blogDetail,
                Categories = categories,
                Products = products,
                About = about,
                Experts = experts,
                Starts = starts,
                Instagram = instagrams
                
            
            };

            return View(homeVM);
        }

       
    }
}