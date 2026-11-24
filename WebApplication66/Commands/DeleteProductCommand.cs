using MediatR;

namespace Shop.Commands;

public record DeleteProductCommand(int Id) : IRequest<bool>;
