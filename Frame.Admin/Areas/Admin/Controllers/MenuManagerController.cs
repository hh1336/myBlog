using Frame.Application.Dtos.MenuManager;
using Frame.Application.Interfaces;
using Frame.WebCore.Authorize;
using Frame.WebCore.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frame.Admin.Areas.Admin.Controllers
{
    //[Authorize]
    //[FrameAuthorize]
    [Area("Admin")]
    public class MenuManagerController : Controller
    {
        private readonly IMenuManagerService _service;

        public MenuManagerController(IMenuManagerService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        /// <summary>
        /// 加载菜单
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> LoadMenu()
        {
            
            return Json(new { });
        }
    }
}
