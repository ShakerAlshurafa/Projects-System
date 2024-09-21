using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPCS.Data;
using SPCS.Models;
using SPCS.Models.project;
using SPCS.ViewModel;

namespace SPCS.Controllers
{
    public class WorkgroupsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public WorkgroupsController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var workgroups = dbContext.Workgroups.ToList();
            var viewModel = mapper.Map<List<WorkgroupVM>>(workgroups);
            return View(viewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var customers = dbContext.Customers.ToList();
            ViewBag.Customers = customers;
            var teams = dbContext.Teams.ToList();
            ViewBag.Teams = teams;
            var projects = dbContext.Projects.ToList();
            ViewBag.Projects = projects;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(WorkgroupVM workgroupVM)
        {
            if (ModelState.IsValid)
            {
                var workgroup = mapper.Map<Workgroup>(workgroupVM);
                dbContext.Workgroups.Add(workgroup);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(workgroupVM);
        }
    }
}
