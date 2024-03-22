using Microsoft.AspNetCore.Mvc;
using SharedLibrary;

namespace AutojustApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessionalManagementController : ControllerBase 
    {
        private readonly ILogger<ProfessionalManagementController> _logger;

        public ProfessionalManagementController(ILogger<ProfessionalManagementController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("/professionals")]
        public IEnumerable<Professional> GetProfessionalList()
        {
            var professionals = MockData.MockProfessional();
            return professionals;
        }

        [HttpGet]
        [Route("/professional")]
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
