using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPCS.Data;
using SPCS.Models;
using SPCS.ViewModel;

namespace SPCS.Controllers
{
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly RoleManager<IdentityRole> roleManager;

        public RolesController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await roleManager.Roles.ToListAsync();
            var roleVM = roles.Select(role => new RoleVM
            {
                Name = role.Name,
            }).ToList();
            return View(roleVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleVM roleVM)
        {
            if (!ModelState.IsValid)
            {
                return View(roleVM);
            }

            var result = await roleManager.CreateAsync(new IdentityRole(roleVM.Name));
            return RedirectToAction("Index");
        }
    }
}
