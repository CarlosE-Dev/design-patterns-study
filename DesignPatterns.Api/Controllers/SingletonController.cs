using DesignPatterns.Infra.Singleton;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Api.Controllers
{
    // This simple controller and endpoints were created to study and practice Singleton Pattern
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SingletonController : ControllerBase
    {
        private readonly SingletonContainer _singletonContainer;
        public SingletonController(SingletonContainer singletonContainer)
        {
            _singletonContainer = singletonContainer;
        }


        // This method should returns a different Guid everytime he's called, since he's not using the Singleton pattern
        [HttpGet("testing-without-singleton")]
        public IActionResult GetWithoutSingleton()
        {
            var singleton = new GetNewGuid();
            return Ok(singleton);
        }


        // This method should return the same Guid every time he's called, using a simple Singleton instance
        [HttpGet("testing-singleton-instance")]
        public IActionResult GetSingletonInstance()
        {
            var singleton = GetNewGuid.Instance;
            return Ok(singleton);
        }


        // This method should return the same Guid every time he's called, using a container with dependency injection
        [HttpGet("testing-singleton-container")]
        public IActionResult GetSingletonContainer()
        {
            return Ok(_singletonContainer);
        }
    }
}
