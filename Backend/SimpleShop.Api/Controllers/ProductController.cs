using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleShop.Application.Entities.Products.Commands;

namespace SimpleShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            if (result.IsSuccessful)
                return Created($"api/product/{result.Value.Id}", result.Value); // Work in progress

            return BadRequest();
        }
    }
}
