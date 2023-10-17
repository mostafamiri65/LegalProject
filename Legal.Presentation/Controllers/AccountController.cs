using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Legal.Application.Services.Interfaces;
using Legal.Application.DTOs.Users;
using Legal.Application.DTOs.Common;
using Legal.Application.Extensions;

namespace Legal.Presentation.Controllers
{
    public class AccountController : BaseController
    {

        #region Ctor
        private IUserService _userService;
        private readonly ICommonService _commonService;
        public AccountController(IUserService userService, ICommonService commonService)
        {
            _userService = userService;
            _commonService = commonService;
        }
        #endregion

        #region LogIn

        [HttpGet("Login")]
        public IActionResult Login(string returnUrl = "")
        {
            var result = new LoginUserDto();
            if (!string.IsNullOrEmpty(returnUrl))
            {
                result.ReturnUrl = returnUrl;
            }
            return View(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserDto login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            if (!string.IsNullOrEmpty(login.Username) && !string.IsNullOrEmpty(login.Password))
            {
                var user = await _userService.GetUserForLogin(login.Username, login.Password);
                if (user.Id == 0)
                {
                    var result = new LoginUserDto();
                    if (!string.IsNullOrEmpty(login.ReturnUrl))
                    {
                        result.ReturnUrl = login.ReturnUrl;
                    }
                    TempData[ErrorMessage] = "اطلاعات وارده اشتباه است";
                    return View(login);
                }

                else
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),


                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = login.RememberMe
                    };

                    await HttpContext.SignInAsync(principal, properties);
                    AppLogDto app = new AppLogDto()
                    {
                        UserId = user.Id,
                        DoingDescription = "وارد سیستم می شود"
                    };
                    await _commonService.AddLog(app);
                }
            }

            if (!string.IsNullOrEmpty(login.ReturnUrl))
            {
                return Redirect(login.ReturnUrl);
            }
            return Redirect("/");
        }

        #endregion

        #region Logout

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {

            AppLogDto app = new AppLogDto()
            {
                UserId =User.GetUserId(),
                DoingDescription = "از سیستم خارج می شود"
            };
            await _commonService.AddLog(app);
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }


        #endregion
    }
}
