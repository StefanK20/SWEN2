using System.Collections.Generic;
using TourPlanner.Models;

namespace TourPlanner.BL.Interface
{
    public interface ILogManager {
	    Log CreateLog(Log log);
	    Log UpdateLog(Log log);
	    void DeleteLog(Log log);
	    IEnumerable<Log> GetLogs(int tourId); 
    }
}
