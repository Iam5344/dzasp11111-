using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Commands;
using Shop.DTOs;
using Shop.Queries;

namespace Shop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetAll(CancellationToken cancellationToken)
    {
        var products = await _mediator.Send(new GetAllProductsQuery(), cancellationToken);
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductReadDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id), cancellationToken);
        return product is null ? NotFound() : Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductReadDto>> Create(ProductCreateDto dto, CancellationToken cancellationToken)
    {
        var created = await _mediator.Send(new CreateProductCommand(dto), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, ProductUpdateDto dto, CancellationToken cancellationToken)
    {
        var updated = await _mediator.Send(new UpdateProductCommand(id, dto), cancellationToken);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await _mediator.Send(new DeleteProductCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}
