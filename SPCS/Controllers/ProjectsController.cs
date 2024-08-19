using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SPCS.Data;
using SPCS.ViewModel;

namespace SPCS.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProjectsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var projects = context.Projects.ToList();
            var viewModel = mapper.Map<List<ProjectVM>>(projects);
            return View(viewModel);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var project = context.Projects.FirstOrDefault(p => p.Id == id);
            if(project == null)
            {
                return NotFound();
            }
            var viewModel = mapper.Map<ProjectDetailsVM>(project);
            return View(viewModel);

        }
    }
}
