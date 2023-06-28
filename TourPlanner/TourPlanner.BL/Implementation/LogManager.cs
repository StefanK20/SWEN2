using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using TourPlanner.BL.Interface;
using TourPlanner.DAL.Interface.SQL;
using TourPlanner.DAL.Implementation.SQL;
using TourPlanner.Models;
using System.Linq;

namespace TourPlanner.BL.Implementation
{
    public class LogManager : ILogManager
    {
        private readonly ILogger _logger;
        private readonly IDataHandler _handler;

        public LogManager(ILogger logger)
        {
            _logger = logger;
            _handler = new DataHandler(logger);
        }

        

        public Log CreateLog(Log log)
        {
            return _handler.AddLog(log);
        }

        public Log UpdateLog(Log log)
        {
            return _handler.UpdateLog(log);
        }

        public void DeleteLog(Log log)
        {
                _handler.DeleteLog(log);
        }


        public IEnumerable<Log> GetLogs(int tourId)
        {
            return _handler.GetLogs(tourId);
        }
    }
}
