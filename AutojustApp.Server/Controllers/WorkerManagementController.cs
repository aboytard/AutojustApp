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
        public IEnumerable<Worker> GetProfessionalList()
        {
            var professionals = MockData.MockProfessional();
            return professionals;
        }

        [HttpGet]
        [Route("/worker/{name}")]
        public Worker GetProfessional(string name)
        {
            return new Worker()
            {
                Name = name,
                PhoneNumber = "numberOf" + name
            };
        }

        [HttpPost]
        [Route("/worker")]
        public Worker Post(Worker professional)
        {
            return professional;
        }
    }
}
