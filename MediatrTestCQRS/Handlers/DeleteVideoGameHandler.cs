using MediatR;
using MediatrTestCQRS.Commands;
using MediatrTestCQRS.Repositories;

namespace MediatrTestCQRS.Handlers
{
    public class DeleteVideoGameHandler : IRequestHandler<DeleteVideoGameCommand>
    {
        private readonly IVideoGameRepository _videoGameRepository;
        public DeleteVideoGameHandler(IVideoGameRepository videoGameRepository)
        {
            _videoGameRepository = videoGameRepository;
        }

        public async Task Handle(DeleteVideoGameCommand request, CancellationToken cancellationToken)
        {
            await _videoGameRepository.DeleteVideoGameByIdAsync(request.Id);
        }
    }
}
