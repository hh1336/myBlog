using Autofac;
using Frame.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Frame.ApplicationCore.Bases.AutoFac
{
    public class AutofacModuleRegister : Autofac.Module
    {
        //重写Autofac管道Load方法，在这里注册注入
        protected override void Load(ContainerBuilder builder)
        {
            //注册Service中的对象,Service中的类要以Service结尾，否则注册失败
            builder.RegisterAssemblyTypes(GetAssemblyByName("Frame.Application")).Where(a => a.Name.EndsWith("Service")).AsImplementedInterfaces();

            //注册上下文
            builder.RegisterType<FrameDbContext>();
            //注册命名空间
            builder.RegisterAssemblyTypes(GetAssemblyByName("Frame.WebCore")).Where(a => a.Namespace.Equals("Frame.WebCore.LoginManager")).AsImplementedInterfaces();
            //注册仓储接口和实现类
            builder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<,>))
           .InstancePerLifetimeScope();
        }
        /// <summary>
        /// 根据程序集名称获取程序集
        /// </summary>
        /// <param name="AssemblyName">程序集名称</param>
        /// <returns></returns>
        public static Assembly GetAssemblyByName(String AssemblyName)
        {
            return Assembly.Load(AssemblyName);
        }
    }
}
