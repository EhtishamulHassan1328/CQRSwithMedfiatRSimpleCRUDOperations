using MediatR;
using MediatrTestCQRS.Models;
using MediatrTestCQRS.Queries;
using MediatrTestCQRS.Repositories;

namespace MediatrTestCQRS.Handlers
{
    public class GetAllVideoGamesHandler : IRequestHandler<GetAllVideoGamesQuery, IEnumerable<VideoGame>>
    {
        private readonly IVideoGameRepository _videoGameRepository;

        public GetAllVideoGamesHandler(IVideoGameRepository videoGameRepository)
        {
            _videoGameRepository = videoGameRepository;
        }
        public async Task<IEnumerable<VideoGame>> Handle(GetAllVideoGamesQuery request, CancellationToken cancellationToken)
        {
            return await _videoGameRepository.GetAllAsync();
        }
    }
}
