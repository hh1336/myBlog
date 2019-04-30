using Frame.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Frame.Admin.Areas.Admin.Controllers
{
    //[Authorize]
    //[FrameAuthorize]
    [Area("Admin")]
    public class AdminHomeController : Controller
    {
        private IHomeService _service;


        public AdminHomeController(IHomeService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            //await _service.Get(Guid.Parse("21D856B4-DABD-4963-B72F-C1BC06A775A7"));
            //var data = new UserInfo
            //var resultbool = await _service.Update();
            return View();
        }
    }
}
