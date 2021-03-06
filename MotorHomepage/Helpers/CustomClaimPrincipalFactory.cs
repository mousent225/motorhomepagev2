﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MotorHomepage.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MotorHomepage.Helpers
{
    public class CustomClaimPrincipalFactory : UserClaimsPrincipalFactory<AppUser, AppRole>
    {
        UserManager<AppUser> _userManager;
        public CustomClaimPrincipalFactory(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
            _userManager = userManager;
        }
        public async override Task<ClaimsPrincipal> CreateAsync(AppUser user)
        {
            var principal = await base.CreateAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            ((ClaimsIdentity)principal.Identity).AddClaims(new[]
            {
                new Claim("Email", user.Email),
                new Claim("FullName", user.FullName),
                new Claim("Avatar", user.Avatar ?? string.Empty),
                new Claim("Roles", string.Join(";", roles))
            });
            return principal;
        }
    }
}
