using MediatR;
using Shop.DTOs;

namespace Shop.Queries;

public record GetAllProductsQuery : IRequest<IEnumerable<ProductReadDto>>;
