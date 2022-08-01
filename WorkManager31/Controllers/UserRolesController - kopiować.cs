using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkManager31.Models;

namespace WorkManager31.Controllers
{
    public class UserRolesController1 : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;

        public UserRolesController1(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            List<UserRolesViewModel> userRolesViewModels = new List<UserRolesViewModel>();

            var users = await _userManager.Users.ToListAsync();

            foreach (ApplicationUser user in users)
            {
                UserRolesViewModel thisUserRole = new UserRolesViewModel();
                thisUserRole.UserId = user.Id;
                thisUserRole.UserName = user.UserName;
                thisUserRole.Email = user.Email;
                thisUserRole.LastName = user.LastName;
                thisUserRole.FirstName = user.FirstName;
                thisUserRole.Roles = await GetUserRoles(user);
                userRolesViewModels.Add(thisUserRole);
            }
            return View(userRolesViewModels);
        }

        private async Task<List<string>> GetUserRoles(ApplicationUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }
    }
}
