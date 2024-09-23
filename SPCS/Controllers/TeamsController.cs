using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPCS.Data;
using SPCS.Models;
using SPCS.ViewModel;

namespace SPCS.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
		private readonly IMapper mapper;

		public TeamsController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
			this.mapper = mapper;
		}
        public IActionResult Index()
        {
            var teams = dbContext.Teams.ToList();
            var teamsVm = mapper.Map<List<TeamVM>>(teams);
            return View(teamsVm);
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TeamVM teamVM)
        {
            if(ModelState.IsValid)
            {
                var team = mapper.Map<Team>(teamVM);
                dbContext.Teams.Add(team);
                dbContext.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
            return View(teamVM);
        }
    }
}
