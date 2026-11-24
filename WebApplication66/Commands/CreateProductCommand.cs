using MediatR;
using Shop.DTOs;

namespace Shop.Commands;

public record CreateProductCommand(ProductCreateDto Dto) : IRequest<ProductReadDto>;
