using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPCS.Data;
using SPCS.Models.user;
using SPCS.Models;
using SPCS.ViewModel;

namespace SPCS.Controllers
{
    public class SupervisorsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public SupervisorsController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var supervisors = dbContext.Supervisors.ToList();
            var viewModel = mapper.Map<List<SupervisorVM>>(supervisors);
            return View(viewModel);
        }

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public IActionResult Create()
		{
			var teams = dbContext.Teams.ToList();
			ViewBag.Teams = teams;
			return View();
        }

        [HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(SupervisorCreateVM supervisorCreateVm)
		{
			if (ModelState.IsValid)
			{
				var supervisor = mapper.Map<Supervisor>(supervisorCreateVm);
				dbContext.Supervisors.Add(supervisor);
				dbContext.SaveChanges();

				return RedirectToAction(nameof(Index));
			}

			return View(supervisorCreateVm);
		}
	}
}
