using Microsoft.AspNetCore.Mvc;

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
            var professionals = new List<Professional>() 
            {
                new Professional()
                    {
                        Name = "Alban",
                        PhoneNumber = "numberOfAlban"
                    },
                new Professional()
                    {
                        Name = "Kane",
                        PhoneNumber = "numberOfKane"
                    },
            };

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
