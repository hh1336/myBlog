using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Frame.Admin.Log4N;
using Frame.Application.AutoMapperConfig;
using Frame.ApplicationCore.Bases.AutoFac;
using Frame.EntityFrameworkCore;
using Frame.WebCore.User;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading;

namespace Frame.Admin
{
    public class Startup
    {
        /// <summary>
        /// log4net 仓储库
        /// </summary>
        public static ILoggerRepository repository { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            #region 配置log4
            repository = LogManager.CreateRepository("Frame.Admin");//需要获取日志的仓库名，也就是你的当然项目名

            //指定配置文件，如果这里你遇到问题，应该是使用了InProcess模式，请查看Blog.Core.csproj,并删之 
            XmlConfigurator.Configure(repository, new FileInfo("log4Net.config"));//配置文件
            #endregion

        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// 配置AutoFac用到的全局字段
        /// </summary>
        public static IContainer AutofacContainer;

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            #region 配置Session
            services.AddSession(o =>
            {
                o.IdleTimeout = TimeSpan.FromMinutes(30);//30分钟超时退出
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential = true;
            });

            #endregion

            #region 配置登陆注解
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(o =>
            {
                o.LoginPath = "/Account/Index";
            });
            #endregion



            #region 配置AutoMapper

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(typeof(MyProfile));
            });

            #endregion

            #region 配置log4

            //log日志注入
            services.AddSingleton<ILoggerHelper, LogHelper>();

            #endregion

            #region 开启在线登陆

            //启动一条线程，用于管理登陆的用户及信息
            Thread thread = new Thread(s => UserManager.Monitor());
            thread.Start();

            #endregion

            services.AddMvc(o =>
            {
                //注入全局捕获异常
                o.Filters.Add(typeof(GlobalExceptionsFilter));

            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            #region 配置log4
            //注入缓存
            services.AddScoped<ICaching, MemoryCaching>();
            services.AddSingleton<IMemoryCache>(factory =>
            {
                var cache = new MemoryCache(new MemoryCacheOptions());
                return cache;
            });
            #endregion

            #region 数据库连接配置
            var sqlConnection = Configuration.GetConnectionString("SqlServerConnection");

            services.AddDbContext<FrameDbContext>(option => option.UseSqlServer(sqlConnection));
            #endregion

            //第三方IOC接管 core内置DI容器 
            return RegisterAutofac(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            #region 加入session
            app.UseSession();
            app.UseAuthentication();
            #endregion

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        /// <summary>
        /// Autofac配置
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private IServiceProvider RegisterAutofac(IServiceCollection services)
        {
            //实例化Autofac容器
            var builder = new ContainerBuilder();
            //将Services中的服务填充到Autofac中
            builder.Populate(services);
            //新模块组件注册    
            builder.RegisterModule<AutofacModuleRegister>();
            //创建容器
            var Container = builder.Build();
            //第三方IOC接管 core内置DI容器 
            return new AutofacServiceProvider(Container);
        }

    }

}
