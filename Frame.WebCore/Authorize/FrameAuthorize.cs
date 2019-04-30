using Frame.ApplicationCore.Bases;
using Frame.Core.Entitys;
using Frame.WebCore.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Frame.WebCore.Authorize
{
    public class FrameAuthorizeAttribute : Attribute, IActionFilter
    {

        /// <summary>
        /// 当请求开始时进入
        /// </summary>
        /// <param name="context"></param>
        public async void OnActionExecuting(ActionExecutingContext context)
        {
            //验证登陆情况
            await VerificationLogin(context);


        }


        /// <summary>
        /// 验证登陆情况
        /// </summary>
        /// <param name="context"></param>
        public async Task VerificationLogin(ActionExecutingContext context)
        {
            if (string.IsNullOrEmpty(context.HttpContext.User.Identity.Name)) { await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme); return; };
            //管道中没有用户信息时退出
            if (context.HttpContext.Session.GetString("IsLogin") == null || !UserManager.Get(context.HttpContext.User.Identity.Name).Result.ResultBool)
            {
                try
                {
                    if (!string.IsNullOrEmpty(context.HttpContext.User.Identity.Name))
                    {
                        await UserManager.RemoveInfo(context.HttpContext.User.Identity.Name);
                        await UserManager.RemoveMonitorUserInfo(context.HttpContext.User.Identity.Name);
                    }
                }
                catch (Exception)
                {
                }
                await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
        }

        /// <summary>
        /// 当请求结束时进入
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }

}
