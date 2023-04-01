using Microsoft.AspNetCore.Mvc;
using WebCore.DB;
using WebCore.Model;

namespace WebCore.Conntroller
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BlogContronller : Controller
    {
        private AppDBContext _dbContext;
        public BlogContronller(AppDBContext dbContext)
        {
            _dbContext= dbContext;
        }
        [HttpGet]
        public  ActionResult<employees> Getemployees() => View(_dbContext.employees.ToList());
      
        [HttpPost]
        public ActionResult  Getemployees(int id) => View(_dbContext.employees.First(e => e.id == id));
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
