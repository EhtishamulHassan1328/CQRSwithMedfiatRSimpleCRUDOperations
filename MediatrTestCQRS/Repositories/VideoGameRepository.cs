using Dapper;
using MediatrTestCQRS.Models;
using Microsoft.Data.SqlClient;

namespace MediatrTestCQRS.Repositories
{
    public class VideoGameRepository : IVideoGameRepository
    {
        private readonly IConfiguration _configuration;

        public VideoGameRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        private SqlConnection GetConncetionString()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }


        public async Task<IEnumerable<VideoGame>> GetAllAsync()
        {
            using var connection = GetConncetionString();
            var videoGames = await connection.
                QueryAsync<VideoGame>("SELECT * FROM VideoGames");
            return videoGames.ToList();
        }


        public async Task<VideoGame> GetByIdAsync(int id)
        {
            using var connection = GetConncetionString();
            var videoGame = await connection.QueryFirstOrDefaultAsync<VideoGame>(
                "SELECT * FROM VideoGames WHERE Id = @Id", new { Id = id });
            return videoGame;
        }

        public async Task<int> CreateVideoGameAsync(VideoGame videoGame)
        {
            using var connection = GetConncetionString();

            var id = await connection.ExecuteScalarAsync<int>(
                @"INSERT INTO VideoGames (Title, Publisher, Developer, ReleaseDate)
          VALUES (@Title, @Publisher, @Developer, @ReleaseDate);
          SELECT CAST(SCOPE_IDENTITY() as int);", videoGame);

            return id;
        }

        public async Task DeleteVideoGameByIdAsync(int id)
        {
            using var connection = GetConncetionString();
            await connection.ExecuteAsync(
                "Delete from VideoGames Where Id = @id", new { Id = id });
        }


        public async Task<int> UpdateVideoGameAsync(VideoGame videoGame)
        {
            using var connection = GetConncetionString();
            var rowsAffected = await connection.ExecuteAsync(
                @"UPDATE VideoGames
                  SET Title = @Title, Publisher = @Publisher, Developer = @Developer, ReleaseDate = @ReleaseDate
                  WHERE Id = @Id", videoGame);
            return rowsAffected;
        }
    }
}
