using Frame.Application.Dtos.ArticleManager;
using Frame.Application.Dtos.LabelManager;
using Frame.Application.Interfaces;
using Frame.ApplicationCore.Common;
using Frame.Core.Entitys;
using Frame.WebCore.Authorize;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Frame.Admin.Areas.Admin.Controllers
{
    [Authorize]
    [FrameAuthorize]
    [Area("Admin")]
    public class ArticleManagerController : Controller
    {
        private readonly IArticleManagerService _service;

        public ArticleManagerController(
            IArticleManagerService service
            )
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }


        /// <summary>
        /// 创建或编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> AddOrEdit(Guid? id)
        {
            ArticleDto data = id.HasValue ? await _service.GetArticleById(id.Value) : new ArticleDto() { ID = Guid.Empty };
            return PartialView(data);
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll(ArticleSreachDto data)
        {
            IPageList<Article> result = await _service.GetAllToPageList(data);
            return Json(result, new Newtonsoft.Json.JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
        }

        /// <summary>
        /// 获取所有标签数据
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetLabel()
        {
            List<ClassifyDto> result = await _service.GetAllLabel();
            return Json(result, new Newtonsoft.Json.JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Save(ArticleDto dto)
        {
            bool result = await _service.Save(dto);
            return Json(new { code = result, msg = result ? "操作成功" : "操作失败" });
        }


        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> SortDel(Guid? id)
        {
            bool result = await _service.SortDel(id);
            return Json(new { code = result, msg = result ? "成功" : "失败" });
        }

        /// <summary>
        /// 上传地址
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Upload()
        {
            var file = Request.Form.Files.First();
            var filename = Guid.NewGuid() + file.FileName;
            //绝对路径路径
            string filepath = Path.GetFullPath("wwwroot/ImageFiles/" + filename);
            //相对路径
            string repath = "/ImageFiles/" + filename;

            //将图片拷贝到ImageFiles目录下
            FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
            await file.CopyToAsync(fs);
            fs.Close();

            return Json(new
            {
                success = 1,
                message = "成功",
                url = repath
            });
        }
    }
}
