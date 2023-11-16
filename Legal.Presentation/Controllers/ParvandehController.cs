using Legal.Application.DTOs.Parvandeh;
using Legal.Application.Extensions;
using Legal.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Legal.Presentation.Controllers
{
    [Authorize]
    public class ParvandehController : Controller
    {
        private readonly IDocService _docService;
        private readonly ICommonService _commonService;

        public ParvandehController(IDocService docService, ICommonService commonService)
        {
            _docService = docService;
            _commonService = commonService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _docService.GetAllParvandeList(User.GetUserId());
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> CreateParvande(int? parvandeId)
        {
            CreateParvandeDto dto = new CreateParvandeDto();
            if (parvandeId != null)
            {
                dto = await _docService.GetParvandeForCreating((int)parvandeId);
            }
            var anvae = await _docService.GetAnvaeParvande();
            ViewData["Anvae"] = anvae;
            var ostan = await _docService.GetOstansByUserId(User.GetUserId());
            ViewData["Ostan"] = ostan;
            return View(dto);
        }

        #region Ajax

        public async Task<IActionResult> GetShahrestan(int ostanId)
        {
            var shahr = await _docService
                .GetAllShahrestansByOstanId(ostanId, User.GetUserId());
            var list = shahr.Where(o => o.OstanId == ostanId).ToList();
            return Json(list);
        }

        public async Task<IActionResult> GetMarja(int noeId, int id)
        {
            if (id != 0)
            {
                await _docService.ChangeParvandeNoe(id, noeId);
            }
            var list = await _docService.GetAllMarjaList(noeId);
            return Json(list);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeMarjeParvande(int id, int marjId)
        {
            if (id != 0)
            {
                await _docService.ChangeMarjaeParvande(id, marjId);
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ChangeShomare24(int id, string shomare)
        {
            if (id != 0)
            {
                await _docService.ChangeShomare24Parvande(id, shomare);
            }
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> ChangeShomareShobe(int id, string shomare)
        {
            if (id != 0)
            {
                await _docService.ChangeShobeParvande(id, shomare);
            }
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetMojtamaes(int shahrId, int id)
        {
            if (id != 0)
            {
                await _docService.ChangeShahrestan(id, shahrId);
            }
            var list = await _docService.GetMojtamahayeParvande(shahrId);
            return Json(list);
        }
        [HttpGet]
        public async Task<IActionResult> CreateParvandeAjax(int id, int noe, int marj, int shahr, string sh24,
            string shShobe, string shP, int mog, string date)
        {
            var pid = 0;
            if (id == 0)
            {
                pid = await _docService.CreateParvande(noe, marj, shahr, sh24, shShobe, shP, mog, date);

            }
            else
            {
                await _docService.ChangeDateIjad(id, date);
                pid = id;
            }
            return Json(pid);
        }

        [HttpGet]
        public IActionResult AddKhahan(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("CreateParvande", new { parvandeId = id });
            }
            CreateShakhsDto dto = new CreateShakhsDto();
            dto.ParvandeId = id;
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AddKhahan(CreateShakhsDto create)
        {
            var list = await _docService.CreateKhahan(create, User.GetUserId());
            return RedirectToAction("CreateParvande",new{ parvandeId =create.ParvandeId});
        }

        #endregion

    }
}
