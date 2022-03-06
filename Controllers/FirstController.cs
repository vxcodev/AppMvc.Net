using System;
using System.IO;
using System.Text;
using AppMvc.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Linq;
using App.Services;

namespace App.Controllers
{
    public class FirstController : Controller{
        private readonly ILogger<FirstController> _logger;
        private readonly ProductService _productService;
        public FirstController(ILogger<FirstController> logger,ProductService productService){
            _logger = logger;
            _productService = productService;
        }
        public string Index(){
            _logger.LogInformation("Index Action");
            return "Controller = First; Action = Index";
        }

        public void Nothing(){
            _logger.LogInformation("Nothing Action");
            string token = Convert.ToBase64String(Encoding.UTF8.GetBytes("Demo"));
            Response.Headers.Add("token",token);
        }
        public object Anything(){
            return DateTime.Now;
        }
        public IActionResult ContentDemo(){
            var content = @"
                Xin chào các bạn,
                Đây là ví dụ về ContentResult

                VXCODE
            ";
            return Content(content,"text/plain");
        }
        public IActionResult EmptyDemo(){
            _logger.LogInformation("Empty Result Action");
            return new EmptyResult();
        }
        public async Task<IActionResult> FileDemo(){
            string filePath = Path.Combine(Startup.ContentRootPath,"Files","Bird.jpg");
            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);

            return File(bytes,"image/jpg");
        }
        public IActionResult JsonDemo(){
            var result = Json(
                new{
                    Name = "IPhone X",
                    Price = 1000,
                    Factory = "US"
                }
            );
            return result;
        }
        public IActionResult LocalRedirectDemo(){
            var url = Url.Action("Privacy","Home");
            _logger.LogInformation("Chuyển hướng đến "+url);
            return LocalRedirect(url);
        }
        public IActionResult RedirectDemo(){
            var url = "https://google.com";
            _logger.LogInformation("Chuyển hướng đến "+url);
            return Redirect(url);
        }
        public IActionResult HelloView(string username){
            if(string.IsNullOrEmpty(username)) username = "Khách";
            // Razor engine tìm file xinchao1.cshtml trong MyView -> xinchao1.cshtml
            //return View("/MyView/xinchao1.cshtml",username);
            // Razor engine tìm xinchao2.cshtml ở trong folder View -> First
            //return View("xinchao2",username);
            // => Controller-> Action=>
            //return View((object)username);
            return View("xinchao3");
        }
        [TempData]
        public string Notify { get; set; }
        public IActionResult ViewProduct(int? id){
            var product = _productService.GetProducts().Where(p=>p.Id==id).FirstOrDefault();
            if(product==null){
                //return NotFound();
                //TempData["Notify"] = "Sản phẩm bạn yêu cầu không có";
                // Có thể viết TempData theo các khai báo property + attribute
                Notify = "Sản phẩm bạn yêu cầu không có @";
                return LocalRedirect(Url.Action("Index","Home"));
            }else{
                // Truyen du lieu bang Model
                //return View(product);
                // Truyen du lieu bang ViewData
                ViewData["product"] = product;
                ViewData["Title"] = product.Name;
                //return View("ViewProduct2");
                // Truyen du lieu bang ViewBag
                ViewBag.product = product;
                return View("ViewProduct3");
            }
            
        }

    }
}