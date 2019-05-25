using Frame.Application.Dtos;
using Frame.Application.Dtos.ArticleManager;
using Frame.Application.Interfaces;
using Frame.ApplicationCore.Common;
using Frame.ApplicationCore.DtoBases;
using Frame.Core.Entitys;
using Frame.WebCore.Redis;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frame.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _service;

        public HomeController(IHomeService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(string acname)
        {
            ViewData["AcName"] = acname;
            return View();
        }

        /// <summary>
        /// 加载用户信息
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetUserInfo()
        {
            UserInfoDto result = await _service.GetUserInfo(Guid.Parse("dfcf9457-40b6-478e-984f-fc29663c3572"));
            return Json(result);
        }

        /// <summary>
        /// 获取所有文章
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetArticles(ArticleSreachDto data)
        {
            IPageList<Article> datalist = await _service.GetArticles(data);
            return Json(datalist,new Newtonsoft.Json.JsonSerializerSettings() {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
        }
    }
}
