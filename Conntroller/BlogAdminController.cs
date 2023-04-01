
using Microsoft.EntityFrameworkCore;
using WebCore.DB;
using WebCore.Model;
using WebCore.ViewModel;
using WebCore.EvenClass;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using SqlSugar.Extensions;

namespace WebCore.Conntroller
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BlogAdminController : Controller
    {
        private readonly AppDBContext _dbContext;
        public BlogAdminController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Get Banner
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetUsers()
        {
          
            List<Users> ltusers =new List<Users> ();
            Users users;
            foreach (var employees in _dbContext.employees.ToList())
            {
                users = new Users();
                users.Id = employees.id;
                users.Yuangongname = employees.yuangongname ;
                ltusers.Add(users);

            }
            //var employees1 = _dbContext.employees.ToList();
          
           var json = EvenJson.SerializeJson<List<Users>>(ltusers);
            if (json == null)
            {
                json = "";
            }
            return ( new JsonResult (new
            { 
                Success=true,
                Message="",
                FileName= json
               
            }));
        }
        public object json { get; set; }
        [HttpPost]
        public async Task<ActionResult> Index(string word, int wage)
        {
            _dbContext.employees.Add(new employees
            {
                word = word,
                wage = wage
            }
                );
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("BlogIndex", "BlogAdmin");
        }
    }
}
