using Microsoft.AspNetCore.Mvc;
using WebCore.API;
using WebCore.Conntroller;
using WebCore.API;
using AutoMapper;
using WebCore.ViewModel;
using Mapster;
using WebCore.Model;

namespace WebCore.Conntroller
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult <IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public  ActionResult <string> Login()
        {
            //Users use = new Users()
            //{
            //    UserId = 1,
            //    UserName = "Name"
            //};
           
            var request = new Users()
            {
                Id=1,
                Yuangongname = "Name"
            };
            Login user = request.Adapt<Login>();
            return "123";
        }
    }
}
