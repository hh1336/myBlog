using Frame.Application.Dtos.LabelManager;
using Frame.Application.Interfaces;
using Frame.ApplicationCore.Bases;
using Frame.ApplicationCore.Common;
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
    public class LabelManagerController : Controller
    {
        private readonly ILabelManagerService _service;
        private readonly IRepository<Classify, Guid> _classifyRepository;


        public LabelManagerController(
            ILabelManagerService service,
            IRepository<Classify, Guid> classifyRepository
            )
        {
            _service = service;
            _classifyRepository = classifyRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }


        /// <summary>
        /// 获取所有数据到表格
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll(SerachLabelDtoInput data)
        {
            IPageList<Classify> result = await _service.GetPageList(data);
            return Json(result,new Newtonsoft.Json.JsonSerializerSettings() {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
        }

        /// <summary>
        /// 创建或编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> AddOrEdit(Guid? id)
        {
            Classify data = id.HasValue ? await _classifyRepository.FirstOrDefaultAsync(s => s.ID == id) : new Classify() { ID = Guid.Empty };
            return PartialView(data);
        }

        /// <summary>
        /// 加载所有菜单项
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

        /// <summary>
        /// 保存方法
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<IActionResult> SaveClassify(ClassifyDto data)
        {
            bool result = await _service.Save(data);
            return Json(new { code = result, msg = result ? "操作成功" : "操作失败" });
        }

        /// <summary>
        /// 删除方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            bool result = id.HasValue ? await _service.Delete(id.Value) : false;
            return Json(new { code = result, msg = result ? "操作成功" : "操作失败" });
        }
    }
}
