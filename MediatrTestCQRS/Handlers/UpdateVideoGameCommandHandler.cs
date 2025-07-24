using MediatR;
using MediatrTestCQRS.Commands;
using MediatrTestCQRS.Models;
using MediatrTestCQRS.Repositories;

namespace MediatrTestCQRS.Handlers
{
    public class UpdateVideoGameCommandHandler : IRequestHandler<UpdateVideoGameCommand, int>
    {
        private readonly IVideoGameRepository _videoGameRepository;

        public UpdateVideoGameCommandHandler(IVideoGameRepository videoGameRepository)
        {
            _videoGameRepository = videoGameRepository;
        }
        public async Task<int> Handle(UpdateVideoGameCommand request, CancellationToken cancellationToken)
        {
            var videoGame = new VideoGame
            {
                Id = request.id,
                Title = request.title,
                Publisher = request.publisher,
                Developer = request.developer,
                ReleaseDate = request.releaseDate
            };
            var query = await _videoGameRepository.UpdateVideoGameAsync(videoGame);
            return query;
        }


    }
}
