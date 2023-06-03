using Fiorello.Data;
using Fiorello.Models;
using Fiorello.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Fiorello.ViewComponents
{
    public class SliderViewComponent :ViewComponent
    {

        private readonly AppDbContext _context;

        public SliderViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<Slider> sliders = await _context.Sliders.ToListAsync();
            SliderInfo sliderInfo = await _context.SlidersInfo.Where(m => !m.SoftDeleted).FirstOrDefaultAsync();
            SliderVM model = new()
            {
                SliderInfo = sliderInfo,
                Sliders = sliders

            };
            return await Task.FromResult((IViewComponentResult)View(model));
        }
    }
}
