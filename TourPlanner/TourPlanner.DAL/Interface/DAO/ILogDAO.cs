using System.Collections.Generic;
using TourPlanner.Models;

namespace TourPlanner.DAL.Interface.DAO
{
    public interface ILogDAO
    {
        IEnumerable<Log> GetLogsByTourId(int tourId);
        Log AddNewLog(Log log);
        Log UpdateLog(Log log);
        bool DeleteLog(int id);
    }
}
