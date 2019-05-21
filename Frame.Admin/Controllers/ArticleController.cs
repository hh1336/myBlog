using Frame.Application.Dtos.ArticleManager;
using Frame.Application.Dtos.Discuss;
using Frame.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frame.Admin.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _service;

        public ArticleController(IArticleService service)
        {
            _service = service;
        }

        /// <summary>
        /// 返回文章内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index(Guid? id)
        {
            ArticleDto data = id.HasValue ? await _service.GetById(id.Value) : new ArticleDto();
            return View(data);
        }

        /// <summary>
        /// 添加评论
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> AddDiscuss(ArticleCommentDto data)
        {
            var userHostAddress = Request.HttpContext.Connection.RemoteIpAddress?.ToString();
            var ipaddress = userHostAddress.Replace("::ffff:", "");
            data.Ip = ipaddress == "::1" ? null : ipaddress;
            data.CommentTime = DateTime.Now;
            bool result = await _service.AddDiscuss(data);

            return Json(new { code = result, msg = result ? "发表成功" : "发表失败" });
        }
    }
}
