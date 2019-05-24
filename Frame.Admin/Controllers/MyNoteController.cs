using Frame.Application.Dtos.ArticleManager;
using Frame.Application.Interfaces;
using Frame.ApplicationCore.Common;
using Frame.Core.Entitys;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frame.Admin.Controllers
{
    public class MyNoteController : Controller
    {
        private readonly IMyNoteService _service;

        public MyNoteController(IMyNoteService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        /// <summary>
        /// 获取所有标签
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetAllLabel()
        {
            List<Classify> data = await _service.GetAllLabel();
            return Json(data);
        }

        /// <summary>
        /// 获取文章
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetArticles(ArticleSreachDto data)
        {
            IPageList<Article> datas = await _service.GetArticles(data);
            return Json(datas, new Newtonsoft.Json.JsonSerializerSettings() {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
        }
    }
}
