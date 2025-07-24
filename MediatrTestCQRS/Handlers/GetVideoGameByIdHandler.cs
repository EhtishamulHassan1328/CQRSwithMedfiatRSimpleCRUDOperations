using MediatR;
using MediatrTestCQRS.Models;
using MediatrTestCQRS.Queries;
using MediatrTestCQRS.Repositories;

namespace MediatrTestCQRS.Handlers
{
    public class GetVideoGameByIdHandler:IRequestHandler<GetVideoGameByIdQuery, VideoGame>
    {
        private readonly IVideoGameRepository _videoGameRepository;

        public GetVideoGameByIdHandler(IVideoGameRepository videoGameRepository)
        {
            _videoGameRepository = videoGameRepository;
        }

        public async Task<VideoGame> Handle(GetVideoGameByIdQuery request, CancellationToken cancellationToken)
        {
            return await _videoGameRepository.GetByIdAsync(request.Id);
        }
    }
}
