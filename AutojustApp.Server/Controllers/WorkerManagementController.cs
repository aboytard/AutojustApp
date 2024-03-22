using Microsoft.AspNetCore.Mvc;
using SharedLibrary;

namespace AutojustApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkerManagementController : ControllerBase 
    {
        private readonly ILogger<WorkerManagementController> _logger;

        public WorkerManagementController(ILogger<WorkerManagementController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("/workers")]
        public IEnumerable<Professional> GetProfessionalList()
        {
            var professionals = MockData.MockProfessional();
            return professionals;
        }

        [HttpGet]
        [Route("/worker/{name}")]
        public Professional GetProfessional(string name)
        {
            return new Professional()
            {
                Name = name,
                PhoneNumber = "numberOf" + name
            };
        }

        [HttpPost]
        [Route("/professional")]
        public Professional Post(Professional professional)
        {
            return professional;
        }
    }
}
