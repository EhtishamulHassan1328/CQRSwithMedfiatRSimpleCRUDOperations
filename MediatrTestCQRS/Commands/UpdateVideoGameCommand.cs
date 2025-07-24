using MediatR;

namespace MediatrTestCQRS.Commands
{
    public record UpdateVideoGameCommand(int id, string title, string publisher, string developer, DateTime releaseDate) : IRequest<int>;

}
