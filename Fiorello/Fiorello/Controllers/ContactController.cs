using Fiorello.Data;
using Fiorello.Models;
using Fiorello.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Controllers
{
    public class ContactController : Controller
    {

        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult>  Index()
        {
            List<Expert> experts = await _context.Experts.Where(m => !m.SoftDeleted).Take(4).ToListAsync();

            ContactVM contactVM = new(){            
            
                Experts=experts
            };
            return View(contactVM);
        }
    }
}
