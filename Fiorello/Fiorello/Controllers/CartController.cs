using Fiorello.Data;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Fiorello.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.ContentModel;

namespace Fiorello.Controllers
{
    public class CartController : Controller
    {

        
        private readonly IProductService _productService;
        private readonly IHttpContextAccessor _accessor;
        private readonly IBasketService _basketService;

        public CartController(IHttpContextAccessor accessor,IBasketService basketService,IProductService productService)
        {

            
            _accessor = accessor;
            _basketService = basketService;
            _productService = productService;
        }


        public async Task<IActionResult> Index()
        {
            List<BasketDetailVM> basketList = new();

            if (_accessor.HttpContext.Request.Cookies["basket"] != null)
            {
                List<BasketVM> basketDatas= JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]);
                foreach (var item in basketDatas)
                {
                    var dbProduct = await _productService.GetByIdWithImageAsnyc(item.Id);
                    
                    
                    if(dbProduct != null)
                    {
                        BasketDetailVM basketDetail = new()
                        {
                            Id = dbProduct.Id,
                            Name = dbProduct.Name,
                            Image = dbProduct.Images.Where(m => m.IsMain).FirstOrDefault().Image,
                            Count = item.Count,
                            Price = dbProduct.Price,
                            TotalPrice = dbProduct.Price * item.Count,
                        };

                        basketList.Add(basketDetail);

                    }
                  
                }
                
            }

            return View(basketList);
        }



        [HttpPost]
        [ActionName("Delete")]
        public async Task< IActionResult> DeleteProduct(int ? id)
        {
            return Ok(await _basketService.DeleteProduct(id));
        }


        [HttpPost]       
        public async Task<IActionResult> AddBasket(int? id)
        {
            if (id is null) return BadRequest();

            Product product = await _productService.GetByIdAsnyc(id);

            if (product is null) NotFound();

            List<BasketVM> basket = _basketService.GetAll();

            _basketService.AddProduct(basket, product);
           
            return Ok(basket.Sum(m=>m.Count));
        }


      


       


     
    }
}
