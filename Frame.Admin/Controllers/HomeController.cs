using Frame.Admin.Models;
using Frame.Application.Interfaces;
using Frame.WebCore.Authorize;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Frame.Admin.Controllers
{
    [Authorize]
    [FrameAuthorize]
    public class HomeController : Controller
    {
        private IHomeService _service;


        public HomeController(IHomeService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var userdto = await _service.Get(Guid.Parse("21D856B4-DABD-4963-B72F-C1BC06A775A7"));
            userdto.UpdateTime = DateTime.Now.Date;
            var resultbool = await _service.Update(userdto);
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            await _service.Get(Guid.Parse("21D856B4-DABD-4963-B72F-C1BC06A775A7"));
            //var data = new UserInfo
            //var resultbool = await _service.Update();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
