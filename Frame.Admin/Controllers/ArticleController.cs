using Frame.Application.Dtos.ArticleManager;
using Frame.Application.Dtos.Discuss;
using Frame.Application.Interfaces;
using Frame.Core.Entitys;
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

        public ArticleController(
            IArticleService service
            )
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

        /// <summary>
        /// 加载评论
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> LoadDiscuss(Guid? id)
        {
            List<ArticleComment> result = await _service.LoadDiscuss(id);
            return Json(result, new Newtonsoft.Json.JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
        }

        /// <summary>
        /// 用户点赞
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> AddLike(Guid? id)
        {
            if (!id.HasValue) return Json(new { msg = "操作错误" });
            var userHostAddress = Request.HttpContext.Connection.RemoteIpAddress?.ToString();
            var ipaddress = userHostAddress.Replace("::ffff:", "");
            if (ipaddress == "::1") return Json(new { msg = "测试" });
            bool result = await _service.AddLike(id.Value,ipaddress);
            return Json(new { msg = result ? "谢谢你哟" : "你已经点过赞了" });
        }


        public async Task<IActionResult> Test()
        {
            await _service.Test();
            return Ok();
        }
    }
}
