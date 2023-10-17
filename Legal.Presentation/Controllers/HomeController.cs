using Legal.Application.DTOs.Common;
using Legal.Application.Extensions;
using Legal.Application.Services.Interfaces;
using Legal.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Legal.Presentation.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ICommonService _commonService;
        public HomeController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        public async Task<IActionResult> Index()
        {
            #region Log
            AppLogDto app = new AppLogDto()
            {
                DoingDescription = "صفحه اصلی داشبورد را باز کرد",
                UserId = User.GetUserId()

            };
            await _commonService.AddLog(app);
            #endregion
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}