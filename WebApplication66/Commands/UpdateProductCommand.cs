using MediatR;
using Shop.DTOs;

namespace Shop.Commands;

public record UpdateProductCommand(int Id, ProductUpdateDto Dto) : IRequest<bool>;
