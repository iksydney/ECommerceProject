﻿using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<AppUser> FindUserByClaimsPrincipalWithAddressAsync(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            //var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            var email = user.FindFirstValue(ClaimTypes.Email);
            var returnedAddress =  await input.Users.Include(x => x.Address).SingleOrDefaultAsync(x => x.Email == email);
            return returnedAddress;
        }

        public static async Task<AppUser> FindByEMailFromClaimPrincipal(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            var email = user.FindFirstValue(ClaimTypes.Email);
            return await input.Users.SingleOrDefaultAsync(x => x.Email == email);
        }
    }
}
