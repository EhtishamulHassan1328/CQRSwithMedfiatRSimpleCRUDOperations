using MediatR;
using MediatrTestCQRS.Models;
using MediatrTestCQRS.Repositories;

namespace MediatrTestCQRS.Handlers
{
    public class CreateVideoGameHandler:IRequestHandler<CreateVideoGameCommand, int>
    {
        private readonly IVideoGameRepository _videoGameRepository;

        public CreateVideoGameHandler(IVideoGameRepository videoGameRepository)
        {
            _videoGameRepository = videoGameRepository;
        }

        public async Task<int> Handle(CreateVideoGameCommand request, CancellationToken cancellationToken)
        {
            var videoGame = new VideoGame
            {
                Title = request.Title,
                Publisher = request.Publisher,
                Developer = request.Developer,
                ReleaseDate = request.ReleaseDate
            };

            return await _videoGameRepository.CreateVideoGameAsync(videoGame);
        }
    }
    
}
