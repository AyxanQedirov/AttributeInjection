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

        public TestController(ITestService testService, ITestRepository testRepository)
        {
            _testService = testService;
            _testRepository = testRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            string name = _testService.GetName();
            string name2=_testRepository.GetName();
            return Ok();
        }
    }
}
