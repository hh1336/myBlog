using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace Frame.Admin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            //让程序找到log4的配置文件
            .ConfigureLogging((hostingContext, loggin) =>
            {
                loggin.AddFilter("System", LogLevel.Warning);
                loggin.AddFilter("Microsoft", LogLevel.Warning);
                loggin.AddLog4Net(System.IO.Directory.GetCurrentDirectory() + "/log4Net.config");
            })
            .UseStartup<Startup>();
    }
}
