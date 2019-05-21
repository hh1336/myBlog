using Frame.Application.Dtos;
using Frame.Application.Interfaces;
using Frame.WebCore.Authorize;
using Frame.WebCore.User;
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
    public class UserInfoSettingsController : Controller
    {
        private IUserInfoSettingsService _service;
        public UserInfoSettingsController(IUserInfoSettingsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var userinfo = await _service.GetById(UserManager.Get(User.Identity.Name).Result.UserInfoID);
            return View(userinfo);
        }

        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SaveUserInfo(UserInfoDto data)
        {
            bool result = await _service.SaveUserInfo(data);
            return Json(new { code = result, msg = result ? "操作成功" : "操作失败" });
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

        /// <summary>
        /// 验证用户信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<IActionResult> UserVilidata(AccountInputDto data)
        {
            bool result = await _service.UserVilidata(data);
            return Json(new { code = result, msg = result ? "验证成功" : "验证失败" });
        }

        /// <summary>
        /// 用户修改密码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<IActionResult> SaveAccountPWD(AccountInputDto data)
        {
            bool result = await _service.SaveAccountPWD(data);
            return Json(new { code = result, msg = result ? "修改成功" : "修改失败" });
        }
    }
}
