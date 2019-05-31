using Microsoft.AspNetCore.Mvc;
using MotorHomepage.Application.Interfaces;
using MotorHomepage.Application.ViewModels.System;
using MotorHomepage.Extensions;
using MotorHomepage.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MotorHomepage.Areas.Admin.Components
{
    public class SideBarViewComponent : ViewComponent
    {
        private ISysMenuService _sysMenuService;

        public SideBarViewComponent(ISysMenuService sysMenuService)
        {
            _sysMenuService = sysMenuService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var roles = ((ClaimsPrincipal)User).GetSpecificClaim("Roles");

            List<SysMenuViewModel> functions;
            if (roles.Split(";").Contains(CommonConstants.AdminRole))
            {
                functions = await _sysMenuService.GetAll();
            }
            else
            {
                //TODO: Get by permission
                functions = new List<SysMenuViewModel>();
            }
            return View(functions);
        }
    }
}
