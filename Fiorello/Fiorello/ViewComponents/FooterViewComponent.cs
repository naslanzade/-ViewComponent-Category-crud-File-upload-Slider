using Fiorello.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private readonly ILayoutService _layoutServie;

        public FooterViewComponent(ILayoutService layoutService)
        {
            _layoutServie = layoutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var datas = _layoutServie.GetAllDatas();
            return await Task.FromResult((IViewComponentResult)View(datas));
        }
    }
}
