using SPCS.Data;
using SPCS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SPCS.ViewModel;
using AutoMapper;

namespace BookStore.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        public UsersController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            this.context = context;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users.ToListAsync();
            var userVM = new List<ApplicationUserVM>();
            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);
                var userData = new ApplicationUserVM
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Address = user.Address,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Roles = roles.ToList(),
                };
                userVM.Add(userData);
            }
            return View(userVM);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            var roles = await roleManager.Roles.ToListAsync();
            var viewModel = new ApplicationUserCreateVM
            {
                Roles = roles.Select(role => new SelectListItem
                {
                    Value = role.Name,
                    Text = role.Name
                }).ToList(),
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicationUserCreateVM userVM)
        {
            if (!ModelState.IsValid)
            {
                return View(userVM);
            }
            var user = new ApplicationUser
            {
                UserName = userVM.UserName,
                Email = userVM.Email,
                Address = userVM.Address,
                PhoneNumber = userVM.PhoneNumber,
            };
            var result = await userManager.CreateAsync(user, userVM.PasswordHash);
            if (!result.Succeeded)
            {
                return View(userVM);
            }
            await userManager.AddToRolesAsync(user, userVM.SelectedRoles);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var roles = await roleManager.Roles.ToListAsync();
            var viewModel = new ApplicationUserCreateVM
            {
                UserName = user.UserName,
                Email = user.Email,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                SelectedRoles = (await userManager.GetRolesAsync(user)).ToList(), 
                Roles = roles.Select(role => new SelectListItem
                {
                    Value = role.Name,
                    Text = role.Name
                }).ToList(),
            };

            return View("Create", viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Update(string id, ApplicationUserCreateVM userVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", userVM);
            }

            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.UserName = userVM.UserName;
            user.Email = userVM.Email;
            user.Address = userVM.Address;
            user.PhoneNumber = userVM.PhoneNumber;

            var result = await userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View("Create", userVM);
            }

            var currentRoles = await userManager.GetRolesAsync(user);
            await userManager.RemoveFromRolesAsync(user, currentRoles);
            await userManager.AddToRolesAsync(user, userVM.SelectedRoles);

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var result = await userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View("Error", ModelState);
            }

            return RedirectToAction("Index");
        }
    }
}
