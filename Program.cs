using Microsoft.OpenApi.Models;
using WebCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

//WebApplication ��ʾ����WebӦ�ó��� ������CreateBuilder()��������һ��WebApplicationBuilder ����
var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);
// ����һ�� WebApplication ʵ����
var app = builder.Build();
startup.Configure(app, app.Environment);

//����Ӧ�ã������ǿ�ʼִ��WebApp �� ������ͻ�����Ǵ���վ Index ҳ���ˣ�
app.Run();


