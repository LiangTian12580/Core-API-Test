
using SqlSugar;
using System.Data;
using DbType = SqlSugar.DbType;

namespace WebCore.DB
{
    /// <summary>
    /// Sqlsugar扩展类
    /// </summary>
    public static class SqlsugarSetup
    {
        public static void AddSqlsugarSetup(this IServiceCollection services, IConfiguration configuration, string dbName = "db_master")
        {
            SqlSugarScope sqlSugar = new SqlSugarScope(new ConnectionConfig()
            {
                DbType = DbType.MySql, //数据库类型
                ConnectionString = configuration.GetConnectionString(dbName), //连接字符串
                IsAutoCloseConnection = true, //是否自动关闭连接
            },
            db =>
            {
                //单例参数配置，所有上下文生效
                db.Aop.OnLogExecuting = (sql, pars) =>
                {
                    Console.WriteLine(sql); //输出sql
                    Console.WriteLine(string.Join(",", pars?.Select(it => it.ParameterName + ":" + it.Value))); //查看执行的sql语句
                };
            });
            services.AddSingleton<ISqlSugarClient>(sqlSugar); //这边是SqlSugarScope用AddSingleton
        }
    }


}
