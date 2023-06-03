using Fiorello.Areas.Admin.ViewModels.Slider;
using Fiorello.Data;
using Fiorello.Helpers;
using Fiorello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _env = webHostEnvironment;
        }
        public async Task< IActionResult> Index()
        {

            List<SliderVM> list = new();
            List<Slider> sliders = await _context.Sliders.Where(m => !m.SoftDeleted).ToListAsync();
            foreach (Slider item in sliders)
            {
                SliderVM model = new()
                {
                    Id = item.Id,
                    Image = item.SliderImage,
                    CreatedDate = item.CreatedDate.ToString("MMMM dd, yyyy"),

                };

                list.Add(model);
            }
            return View(list);
        }


        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderCreateVM request)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            if (!request.Image.CheckFileType("image/"))
            {
                ModelState.AddModelError("image", "Please select only image file");
                return View();
            }

            if (request.Image.CheckFileSize(200))
            {
                ModelState.AddModelError("image", "Image size must be max 200KB");
                return View();
            }



            string fileName=Guid.NewGuid().ToString()+"_"+request.Image.FileName;

            await request.Image.SaveFileAsync(fileName, _env.WebRootPath, "img");


            Slider slider = new() 
            {
                SliderImage=fileName
            };

            await _context.Sliders.AddAsync(slider);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
