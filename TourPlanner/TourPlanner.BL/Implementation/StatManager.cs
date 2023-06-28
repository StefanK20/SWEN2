using Microsoft.Extensions.Logging;
using TourPlanner.BL.Interface;
using TourPlanner.DAL.Implementation.SQL;
using TourPlanner.DAL.Interface.SQL;
using TourPlanner.DAL.SQL;

namespace TourPlanner.BL.Implementation
{
    public class StatManager : IStatManager
    {
        private readonly ILogger _logger;
        private readonly IDataHandler _handler;

        public StatManager(ILogger logger)
        {
            _logger = logger;
            _handler = new DataHandler(logger);
        }

        public int GetLogCount(int id)
        {
            return _handler.GetLogCount(id);
        }

        public double GetAvgRating(int id)
        {
            return _handler.GetAvgRating(id);
        }

        public double GetAvgDifficulty(int id)
        {
            return _handler.GetAvgDifficulty(id);
        }

        public int GetAvgDuration(int id)
        {
            return _handler.GetAvgDuration(id);
        }

        /// <summary>
        /// Calculate Popularity: Count * Avg-Rating 
        /// </summary>
        /// <param name="id">Tour Id</param>
        /// <returns>Popularity to 2 decimal digits</returns>
        public double GetPopularity(int id)
        {
            return GetLogCount(id) * GetAvgRating(id);
        }

        /// <summary>
        /// Calculate Child-Friendliness: 10 - Avg-Difficulty
        /// </summary>
        /// <param name="id">Tour Id</param>
        /// <returns>0 if there are no logs, otherwise child-friendliness to 2 decimal digits</returns>
        public double GetChildFriendliness(int id)
        {
            return GetLogCount(id) <= 0 ? 0 : 10 - GetAvgDifficulty(id);
        }
    }
}
