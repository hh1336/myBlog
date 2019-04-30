using Frame.WebCore.LoginManager;
using Frame.WebCore.LoginManager.Dtos;
using Frame.WebCore.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Frame.Admin.Areas.Admin.Controllers
{
    /// <summary>
    /// 登陆功能 
    /// </summary>
    [Area("Admin")]
    public class AccountController : Controller
    {
        private ILoginManager _loginManager;

        public AccountController(ILoginManager loginManager)
        {
            _loginManager = loginManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region 登陆

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="modal"></param>
        /// <returns></returns>
        public async Task<IActionResult> Login(LoginDto modal)
        {
            //登陆验证并得到用户信息
            var loginResult = await _loginManager.Login(modal);

            if (loginResult.ResultBool)
            {
                //登陆
                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,modal.AccountNumber)
            };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));


                //得到当前登陆的ip
                var userHostAddress = Request.HttpContext.Connection.RemoteIpAddress?.ToString();
                var ipaddress = userHostAddress.Replace("::ffff:", "");
                if (ipaddress != "::1")
                {
                    loginResult.IPAddress = ipaddress;
                }
                //更新用户登陆信息
                await _loginManager.UpdateLoginInfo(loginResult.AccountID, loginResult.IPAddress);

                //将用户信息加入全局，并且使用在线功能
                await UserManager.Add(loginResult);

            }

            return Json(new { code = loginResult.ResultBool, url = loginResult.ResultBool ? "/Admin/AdminHome/Index" : "", msg = loginResult.MessAge });
        }

        /// <summary>
        /// 退出登陆
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> LoginOut()
        {
            await UserManager.RemoveInfo(HttpContext.User.Identity.Name);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Home");
        }

        #endregion
    }
}
