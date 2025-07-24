using MediatR;

namespace MediatrTestCQRS.Commands
{
    public record DeleteVideoGameCommand(int Id) : IRequest;
}
