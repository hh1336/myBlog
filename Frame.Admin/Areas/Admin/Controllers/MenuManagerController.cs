using Frame.Application.Dtos.MenuManager;
using Frame.Application.Interfaces;
using Frame.Core.Entitys;
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
    [Authorize]
    [FrameAuthorize]
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
            var result = await _service.GetAllMenuIncludeChildren();
            return Json(result, new Newtonsoft.Json.JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
        }

        /// <summary>
        /// 创建或编辑菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> AddOrEditMenu(Guid? id)
        {
            AdminMenu data = !id.HasValue ? new AdminMenu() { ID = Guid.Empty } : await _service.GetByMenuId(id.Value);
            return PartialView(data);
        }

        /// <summary>
        /// 加载所有父级菜单
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetParentMenu()
        {
            List<AdminMenu> result = await _service.GetParentMenu();
            return Json(result);
        }

        public async Task<IActionResult> GetAllMenu()
        {
            List<AdminMenu> result = await _service.GetAllMenu();
            return PartialView(result);
        }

        /// <summary>
        /// 保存菜单信息
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Save(AdminMenuDto data)
        {
            bool result = await _service.SaveMenuInfo(data);
            return Json(result);
        }

    }
}
