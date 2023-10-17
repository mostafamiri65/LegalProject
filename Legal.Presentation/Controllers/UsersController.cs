using Legal.Application.DTOs.Common;
using Legal.Application.DTOs.Users;
using Legal.Application.Extensions;
using Legal.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace Legal.Presentation.Controllers
{
    [Authorize]
    public class UsersController : BaseController
    {
        #region Ctor
        private readonly IUserService _userService;
        private readonly ICommonService _commonService;
        public UsersController(IUserService userService, ICommonService commonService)
        {
            _userService = userService;
            _commonService = commonService;
        }
        #endregion
        #region UserList
        public async Task<IActionResult> Index()
        {
            #region Log
            AppLogDto app = new AppLogDto()
            {
                DoingDescription = "صفحه کاربران سامانه را باز کرد",
                UserId = User.GetUserId(),
                TableName = "TbUsers"
            };
            await _commonService.AddLog(app);
            #endregion
            var list = await _userService.GetUsers(User.GetUserId());
            ViewBag.CanEdit = await _userService.CanEditUser(User.GetUserId());
            return View(list);
        }
        #endregion
        #region CreateUser
        [HttpGet]
        public async Task<IActionResult> CreateUser()
        {
            var canAdd = await _userService.CanAddUser(User.GetUserId());
            if (!canAdd)
            {
                TempData[ErrorMessage] = "شما دسترسی به این قسمت را ندارید";
                AppLogDto app2 = new AppLogDto()
                {
                    DoingDescription = "اجازه دسترسی به ثبت کاربر جدید را ندارد",
                    UserId = User.GetUserId(),
                    TableName = "TbUsers"
                };
                await _commonService.AddLog(app2);
                return RedirectToAction("Index");
            }
            #region Log
            AppLogDto app = new AppLogDto()
            {
                DoingDescription = "صفحه کاربر جدید را باز کرد",
                UserId = User.GetUserId(),
                TableName = "TbUsers"
            };
            await _commonService.AddLog(app);
            #endregion
            var regions = await _commonService.GetAllRegions();
            var roles = await _userService.GetRoles();
            ViewData["Roles"] = roles;
            ViewData["Regions"] = regions;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto create)
        {

            var result = await _userService.CreateUser(create, User.GetUserId());
            #region Log
            AppLogDto app = new AppLogDto()
            {
                DoingDescription = "کاربر جدیدی برای سامانه تعریف کرد",
                UserId = User.GetUserId(),
                TableName = "TbUsers"
            };
            await _commonService.AddLog(app);
            #endregion
            if (!result) TempData[ErrorMessage] = "نام کاربری یا شماره موبایل تکراری است";
            return RedirectToAction("Index");
        }

        #endregion
        #region Edit User And Change Password
        public async Task<IActionResult> EditUser(long userId)
        {
            var canEdit = await _userService.CanEditUser(User.GetUserId());
            if (!canEdit)
            {
                #region Log
                AppLogDto app2 = new AppLogDto()
                {
                    DoingDescription = "دسترسی به صفحه ویرایش کاربر را ندارد",
                    UserId = User.GetUserId(),
                    TableName = "TbUsers"
                };
                await _commonService.AddLog(app2);
                #endregion
                return RedirectToAction("Index");
            }
            #region Log
            AppLogDto app = new AppLogDto()
            {
                DoingDescription = "صفحه ویرایش کاربر را باز کرد",
                UserId = User.GetUserId(),
                TableName = "TbUsers"
            };
            await _commonService.AddLog(app);
            #endregion
            var regions = await _commonService.GetAllRegions();
            var roles = await _userService.GetRoles();
            ViewData["Roles"] = roles;
            ViewData["Regions"] = regions;
            var user = await _userService.GetUserById(userId);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(UserDto user)
        {
            var editUser = await _userService.UpdateUser(user, User.GetUserId());
            if (editUser == false)
            {
                TempData[ErrorMessage] = "انجام نشد";
            }

            #region Log
            AppLogDto app = new AppLogDto()
            {
                DoingDescription = " ویرایش کاربر را با موقیت انجام داد",
                UserId = User.GetUserId(),
                TableName = "TbUsers"
            };
 #endregion
            return RedirectToAction("Index");
           
        }
        public IActionResult ChangePassword(long userId)
        {
            ChangePasswordDto dto = new ChangePasswordDto()
            {
                Id = userId
            };
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto change)
        {
            await _userService.ChangePassword(change);
            return RedirectToAction("Index");
        }
        #endregion


        #region Ajax Actions
        public async Task<IActionResult> GetOstans(int? regionId)
        {
            var ostans = await _commonService.GetAllOstans();
            if (regionId != null)
            {
                ostans = ostans.Where(o => o.RegionId == regionId).ToList();
            }

            return Json(ostans);
        }

        public async Task<IActionResult> GetShahrs(int ostanId)
        {
            var shahr = await _commonService.GetAllShahrestans();
            var list = shahr.Where(o => o.OstanId == ostanId).ToList();
            return Json(list);
        }
        #endregion
    }
}
