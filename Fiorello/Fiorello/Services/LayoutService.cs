using Fiorello.Data;
using Fiorello.Services.Interfaces;
using Fiorello.ViewModels;
using Newtonsoft.Json;
using System.Linq;

namespace Fiorello.Services
{
    public class LayoutService : ILayoutService
    {

        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _accessor;
        private readonly IBasketService _basketService;

        public LayoutService(AppDbContext context, IHttpContextAccessor accessor, IBasketService basketService)
        {
            _context = context;
            _accessor = accessor;
            _basketService = basketService;
        }
        public LayoutVM GetAllDatas()
        {
            int count=_basketService.GetCount();
            var datas= _context.Settings.AsEnumerable().ToDictionary(m => m.Key, m => m.Value);
            return new LayoutVM { BasketCount=count,SettingDatas=datas};
            
        }

      
    }
}
