using management.Application.Services;
using management.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace management.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase // 👈 plural por convención REST
    {
        private readonly OrderService _service;

        public OrdersController(OrderService service)
        {
            _service = service;
        }

        // 🔹 GET: api/orders
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _service.GetAllAsync();
            return Ok(orders);
        }

        // 🔹 GET: api/orders/5
        // [HttpGet("{id:int}")]
        // public async Task<IActionResult> GetById(int id)
        // {
        //     var order = await _service.
        //     if (order == null) return NotFound();
        //     return Ok(order);
        // }

        // 🔹 POST: api/orders
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Order order)
        {
            if (order == null) return BadRequest("El cuerpo de la solicitud está vacío.");
            
            var created = await _service.CreateAsync(order);
            return CreatedAtAction(nameof(created), new { id = created.Id }, created);
        }

        // 🔹 PUT: api/orders/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Order order)
        {
            if (order == null || id != order.Id)
                return BadRequest("Los datos de la orden no coinciden.");

            var updated = await _service.UpdateAsync(id, order);
            return Ok(updated);
        }

        // 🔹 DELETE: api/orders/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return Ok(deleted);
        }
    }
}