using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Models;

namespace TourPlanner.DAL.Interface.SQL
{
    public interface IDataHandler
    {
        // Tours
        public IEnumerable<Tour> GetTours();
        public Tour AddTour(Tour newTour);
        public Tour UpdateTour(Tour newTour);
        public void DeleteTour(Tour tour);

        // TourLogs
        public IEnumerable<Log> GetLogs(int tourId);
        public Log AddLog(Log newLog);
        public Log UpdateLog(Log log);
        public void DeleteLog(Log log);
        IEnumerable<Tour> SearchTours(string searchTerm);
        void SetImagePath(int id, string imagePath);
        int GetLogCount(int id);
        double GetAvgRating(int id);
        double GetAvgDifficulty(int id);
        int GetAvgDuration(int id);
        void SaveDBChanges();
    }
}
