using MediatR;
using MediatrTestCQRS.Models;

public record CreateVideoGameCommand(string Title, string Publisher, string Developer, DateTime ReleaseDate)
    : IRequest<int>;
