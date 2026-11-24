using AutoMapper;
using MediatR;
using Shop.Data;
using Shop.DTOs;
using Shop.Models;

namespace Shop.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductReadDto>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProductReadDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request.Dto);

        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ProductReadDto>(product);
    }
}
