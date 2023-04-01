using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql;
using System.Configuration;
using System.Runtime.Intrinsics.X86;
using System.Security.Policy;
using WebCore.DB;

namespace WebCore
{
    public class Startup
    {
        public Startup(IConfiguration context)
        {
            _context = context;

        }
        private readonly IConfiguration _context;

        public void ConfigureServices(IServiceCollection services)
        {
            //DB连接
            var connection = _context["Connection"];
            services.AddDbContext<AppDBContext>(
        options => options.UseMySql(connection,new MySqlServerVersion (new Version())));

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<AppDBContext>();
            services.AddCors(c =>
            {
                c.AddPolicy("Cors", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
            // 配置Swagger
            //注册Swagger生成器，定义一个Swagger 文档
            services.AddSwaggerGen(c =>
           {
               c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
               {
                   Version = "v1",
                   Title = "GTrackAPI"
               });
               // 为 Swagger 设置xml文档注释路径
               //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
               //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
               //c.IncludeXmlComments(xmlPath);
               });
               //Add services to the container.
               services.AddDistributedMemoryCache();
            // WebApplicationBuilder 对象添加 RazorPages 服务 ， 也可以添加其他服务，比如依赖注入、登录等。
            services.AddRazorPages(options =>
            {
                options.Conventions.AddPageRoute("/default", "");
            });
            services.AddMvcCore()
                    .AddApiExplorer();
          
            
            services.AddAutoMapper(typeof(Startup));

        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {

            if (app.Environment.IsDevelopment())
            {
                //启用中间件服务生成Swagger
                app.UseSwagger();
                //启用中间件服务生成SwaggerUI，指定Swagger JSON终结点
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web App V1");
                    c.RoutePrefix = string.Empty;//设置根节点访问
                                                 //});
                    app.UseExceptionHandler("/Error");
                });
                };
            app.UseCors("Cors");
            app.UseDefaultFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        }
      
    }
}
