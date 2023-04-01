using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebCore.API;

namespace WebCore.Conntroller
{
    /// <summary>
    /// Jwt控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public JwtController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        /// <summary>
        /// 获取Jwt字符串
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string CreateToken()
        {
            var tokenModel = this._configuration.GetSection("Jwt").Get<TokenModelJwt>(); //获取TokenModelJwt对象
            tokenModel.UserName = "ghy";
            tokenModel.UserId = 1;
            tokenModel.Role = "Admin";
            tokenModel.Expires = 60 * 30; //过期时间默认设置为30min
            return JwtHelper.CreateJwt(tokenModel);
        }
    }

}
