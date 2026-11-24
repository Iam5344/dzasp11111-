using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.DTOs;

namespace Shop.Queries;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductReadDto>>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductReadDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _context.Products
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<ProductReadDto>>(products);
    }
}
