using DesignPatterns.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DesignPatterns.Api.Controllers
{
    // This simple controller and endpoint were created to study and practice Facade Pattern
    // Validations and some good practices were not so relevant here, the focus is just to make the Facade Pattern flow work
    [Route("api/[controller]")]
    [ApiController]
    public class PersonActionsController : ControllerBase
    {
        private readonly IPersonActions _personActions;
        public PersonActionsController(IPersonActions personActions)
        {
            _personActions = personActions;
        }

        // This method must call another POST method.
        // It was implemented as a way to start our Facade Pattern flow
        // That's also a way to pass the Person that will do some action
        [HttpPut("{id}/depositMoney")]
        public IActionResult DepositMoney(Guid id)
        {
            _personActions.DepositMoney(id);

            return NoContent();
        }
    }
}
