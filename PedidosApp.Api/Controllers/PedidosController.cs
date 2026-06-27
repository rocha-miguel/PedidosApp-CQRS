using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using PedidosApp.Api.Commands;
using PedidosApp.Api.Contexts;
using PedidosApp.Api.Models;


namespace PedidosApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PedidosController(IMediator mediator, MongoDbContext mongoDbContext) : ControllerBase {

    [HttpPost]
    public async Task<IActionResult> PostPedidosAsync([FromBody] PedidoCreateCommand command) {

        try {

            await mediator.Send(command);

            return StatusCode(201, command);

        } catch {

            throw;
        }

    }

    [HttpPatch]
    public async Task<IActionResult> PatchPedidosAsync([FromBody] PedidoUpdateCommand command) {

        try {

            await mediator.Send(command);

            return Ok(command);

        } catch {

            throw;
        }

    }

    [HttpGet]
    public async Task<IActionResult> GetAllPedidosAsync() {

        try {

            var filter = Builders<Pedidos>.Filter.Empty;

            var pedidos = await mongoDbContext.Pedidos
                .Find(filter)
                .ToListAsync();

            return Ok(pedidos);
        } catch {

            throw;
        }

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdPedidoAsync(Guid id) {

        try {

            var filter = Builders<Pedidos>.Filter.Empty;

            var pedido = await mongoDbContext.Pedidos
                .Find(filter)
                .FirstOrDefaultAsync();

            return Ok(pedido);
        } catch {

            throw;
        }

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePedidoAsync(Guid id) {

        try {

            var command = new PedidoDeleteCommand { Id = id };

            await mediator.Send(command);

            return NoContent();

        } catch {

            throw;
        }

    }


}

