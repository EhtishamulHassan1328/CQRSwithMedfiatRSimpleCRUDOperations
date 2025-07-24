using MediatR;
using MediatrTestCQRS.Models;

namespace MediatrTestCQRS.Queries
{
    public class GetAllVideoGamesQuery : IRequest<IEnumerable<VideoGame>>
    {

    }
}
