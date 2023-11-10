using Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly ITestRepository _testRepository;
        private readonly IManualService _manualService;

        public TestController(ITestService testService, ITestRepository testRepository, IManualService manualService)
        {
            _testService = testService;
            _testRepository = testRepository;
            _manualService = manualService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            string name = _testService.GetName();
            string name2=_testRepository.GetName();
            string name3 = _manualService.Message();
            return Ok();
        }
    }
}
