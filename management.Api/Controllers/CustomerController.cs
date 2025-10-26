using Microsoft.AspNetCore.Mvc;
using management.Application.Services;
using management.Domain.Models;

namespace management.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _service;

        public CustomerController(CustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllClients());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _service.GetById(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Customer customer)
        {
            var created = _service.Add(customer);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] Customer customer)
        {
            if (id != customer.Id)
                return BadRequest();

            _service.Edit(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
