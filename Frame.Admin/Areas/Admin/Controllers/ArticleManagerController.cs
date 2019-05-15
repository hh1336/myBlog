using Frame.Application.Dtos.ArticleManager;
using Frame.Application.Interfaces;
using Frame.Core.Entitys;
using Frame.WebCore.Authorize;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
    }
}
