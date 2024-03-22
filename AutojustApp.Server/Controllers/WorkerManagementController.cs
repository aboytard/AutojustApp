using Microsoft.AspNetCore.Mvc;
using SharedLibrary;
using SharedLibrary.Entities;
using SharedLibrary.Interfaces;

namespace AutojustApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkerManagementController : ControllerBase 
    {
        private readonly ILogger<WorkerManagementController> _logger;
        private IWorkerServiceManager _workerManagerService;

        public WorkerManagementController(IWorkerServiceManager workerManagerService, ILogger<WorkerManagementController> logger)
        {
            _workerManagerService = workerManagerService;
            _logger = logger;
        }

        [HttpGet]
        [Route("/workers")]
        public async Task<IActionResult> GetProfessionalList()
        {
            var result = await _workerManagerService.GetAll();
            if (result.Success)
                return Ok(result.Data);
            else
                return StatusCode(500, result.ErrorMessage);
        }

        [HttpGet]
        [Route("/worker/{name}")]
        public async Task<IActionResult> GetProfessional(string name)
        {
            var result = await _workerManagerService.Get(name);
            if (result.Success)
                return Ok(result.Data);
            else
                return StatusCode(500, result.ErrorMessage);
        }

        [HttpPost]
        [Route("/worker")]
        public async Task<IActionResult> Post(Worker worker)
        {
            var result = await _workerManagerService.Add(worker);
            if (result.Success)
                return Ok(result.Data);
            else
                return StatusCode(500, result.ErrorMessage);
        }

        [HttpPut]
        [Route("/worker")]
        public async Task<IActionResult> Update(Worker worker)
        {
            var result = await _workerManagerService.Update(worker);
            if (result.Success)
                return Ok(result.Data);
            else
                return StatusCode(500, result.ErrorMessage);
        }

        [HttpDelete]
        [Route("/worker/{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            var result = await _workerManagerService.Delete(name);
            if (result.Success)
                return Ok();
            else
                return StatusCode(500, result.ErrorMessage);
        }
    }
}
