using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Data;

namespace Shop.Commands;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (product is null)
        {
            return false;
        }

        _mapper.Map(request.Dto, product);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
