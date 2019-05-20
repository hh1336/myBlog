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
    public class JournalLableController : Controller
    {
        private IJournalLableService _service;
        private IRepository<Classify, Guid> _classifyRepository;

        public JournalLableController(IJournalLableService service, IRepository<Classify, Guid> classifyRepository)
        {
            _service = service;
            _classifyRepository = classifyRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        /// <summary>
        /// 获取表格数据
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetAll(SerachLabelDtoInput dto)
        {
            IPageList<Classify> result = await _service.GetAll(dto);
            return Json(result, new Newtonsoft.Json.JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
        }

        /// <summary>
        /// 返回新增或修改页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> AddOrEdit(Guid? id)
        {
            Classify result = id.HasValue ? await _classifyRepository.FirstOrDefaultAsync(s => s.ID == id) : new Classify() { ID = Guid.Empty };
            return PartialView(result);
        }


        /// <summary>
        /// 保存方法
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> SaveClassify(ClassifyDto data)
        {
            bool result = await _service.Save(data);
            return Json(new { code = result, msg = result ? "操作成功" : "操作失败" });
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            bool result = id.HasValue ? await _service.Delete(id.Value) : false;
            return Json(new { code = result, msg = result ? "操作成功" : "操作失败" });
        }
    }
}
