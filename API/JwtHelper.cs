using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using System.Text;

namespace WebCore.API
{
    /// <summary>
    /// Jwt帮助类
    /// </summary>
    public static class JwtHelper
    {
        /// <summary>
        /// 创建Jwt字符串
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string CreateJwt(TokenModelJwt model)
        {
            var claims = new List<Claim>
            {
                new Claim("UserId",model.UserId.ToString()), //保存用户Id
                new Claim("UserName",model.UserName), //保存用户名称
                new Claim("Role", model.Role) //保存用户角色
            };

            /*
            //秘钥 分开的写法
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(model.Secret));
            var creds = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(model.Secret)), SecurityAlgorithms.HmacSha256);
            */

            var jwt = new JwtSecurityToken(
                issuer: model.Issuer,
                audience: model.Audience,
                expires: DateTime.Now.AddSeconds(model.Expires),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(model.Secret)),
                SecurityAlgorithms.HmacSha256),
                claims: claims
            );

            /* 分开的写法
            var jwtHandler = new JwtSecurityTokenHandler();
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            */

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        /// <summary>
        /// 解析Jwt字符串并转换为TokenModelJwt对象
        /// </summary>
        /// <param name="jwtStr"></param>
        /// <returns></returns>
        public static TokenModelJwt SerializeJwt(string jwtStr)
        {
            //解析token
            var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(jwtStr);
            var tokenJwt = JsonConvert.DeserializeObject<TokenModelJwt>(jwtToken.Payload.SerializeToJson());
            return tokenJwt;
        }

    }

    /// <summary>
    /// 令牌对象
    /// </summary>
    public class TokenModelJwt
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 发行人
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        /// 观众
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// 秘钥
        /// </summary>
        public string Secret { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public int Expires { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public string Role { get; set; }
    }
}


