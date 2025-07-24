using MediatR;
using MediatrTestCQRS.Models;

namespace MediatrTestCQRS.Queries
{
    public record GetVideoGameByIdQuery(int Id) : IRequest<VideoGame>;

}
