using Microsoft.OpenApi.Models;
using WebCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

//WebApplication 表示整个Web应用程序 ，调用CreateBuilder()方法创建一个WebApplicationBuilder 对象。
var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);
// 构造一个 WebApplication 实例。
var app = builder.Build();
startup.Configure(app, app.Environment);

//启动应用，当我们开始执行WebApp ， 浏览器就会帮我们打开网站 Index 页面了，
app.Run();


