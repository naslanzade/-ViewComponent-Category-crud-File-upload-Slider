using Fiorello.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.ViewComponents
{
    public class HeaderViewComponent :ViewComponent
    {

        private readonly ILayoutService _layoutServie;

        public HeaderViewComponent(ILayoutService layoutService)
        {
            _layoutServie = layoutService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            var datas=_layoutServie.GetAllDatas();
            return await Task.FromResult((IViewComponentResult)View(datas));
        }

    }
}
