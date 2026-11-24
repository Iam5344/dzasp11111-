using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.DTOs;

namespace Shop.Queries;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductReadDto?>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProductReadDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        return product is null ? null : _mapper.Map<ProductReadDto>(product);
    }
}
