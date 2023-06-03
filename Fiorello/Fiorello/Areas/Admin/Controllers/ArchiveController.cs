using Fiorello.Areas.Admin.ViewModels.Category;
using Fiorello.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArchiveController : Controller
    {
        private readonly AppDbContext _context;
        public ArchiveController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Categories()
        {

            List<CategoryVM> list = new();
            var datas = await _context.Categories.Where(m=>m.SoftDeleted).IgnoreQueryFilters().ToListAsync();
            foreach (var item in datas)
            {
                list.Add(new CategoryVM
                {
                    Id = item.Id,
                    Name = item.Name,
                });
            }
            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExtractCategory(int id)
        {
            var existCategory = await _context.Categories.Where(m => m.SoftDeleted).IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == id);

            existCategory.SoftDeleted = false;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Categories));

        }
    }


}
