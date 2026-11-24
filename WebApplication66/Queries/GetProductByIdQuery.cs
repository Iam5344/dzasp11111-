using MediatR;
using Shop.DTOs;

namespace Shop.Queries;

public record GetProductByIdQuery(int Id) : IRequest<ProductReadDto?>;
