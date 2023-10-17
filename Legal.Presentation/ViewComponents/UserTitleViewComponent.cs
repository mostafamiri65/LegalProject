using Legal.Application.Extensions;
using Legal.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Legal.Presentation.ViewComponents
{
    public class UserTitleViewComponent : ViewComponent
    {
        IUserService _accountingService;
        public UserTitleViewComponent(IUserService accountingService)
        {
            _accountingService = accountingService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _accountingService.GetUserFullnameById(HttpContext.User.GetUserId());
            return View(user);
        }
    }
}
