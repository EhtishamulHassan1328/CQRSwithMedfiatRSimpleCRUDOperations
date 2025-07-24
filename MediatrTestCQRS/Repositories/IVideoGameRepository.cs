using MediatrTestCQRS.Models;

namespace MediatrTestCQRS.Repositories
{
    public interface IVideoGameRepository
    {
        Task<IEnumerable<VideoGame>> GetAllAsync();
        Task<VideoGame> GetByIdAsync(int id);
        Task<int> CreateVideoGameAsync(VideoGame videoGame);
        Task DeleteVideoGameByIdAsync(int id);
        Task<int> UpdateVideoGameAsync(VideoGame videoGame);
    }

}
