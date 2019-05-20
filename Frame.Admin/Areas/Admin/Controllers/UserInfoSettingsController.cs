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
    }
}
