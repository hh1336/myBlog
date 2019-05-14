using Frame.Application.Dtos.MenuManager;
using Frame.Application.Interfaces;
using Frame.Core.Entitys;
using Frame.WebCore.Authorize;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Frame.Admin.Areas.Admin.Controllers
{
    [Authorize]
    [FrameAuthorize]
    [Area("Admin")]
    public class AdminHomeController : Controller
    {
        private IHomeService _service;


        public AdminHomeController(
            IHomeService service
            )
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            return View();
        }

        /// <summary>
        /// 加载菜单
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> LoadMenu()
        {
            List<AdminMenu> result = await _service.GetAllMenu();
            return Json(result, new Newtonsoft.Json.JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
        }
    }
}
