using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.DAL.Interface.SQL;
using TourPlanner.DAL.SQL;
using TourPlanner.Models;

namespace TourPlanner.DAL.Implementation.SQL
{
    public class DataHandler : IDataHandler
    {
        private readonly ILogger _logger;
        private readonly TourPlannerContext context = new();

        public DataHandler(ILogger logger)
        {
            context.Database.EnsureCreated();
            _logger = logger;
        }

        public DataHandler(ILogger logger, TourPlannerContext @object) : this(logger)
        {
        }

        public Tour AddTour(Tour newTour)
        {
            context.Tours.Add(newTour);
            return newTour;
        }

        public void SaveDBChanges()
        {
            context.SaveChanges();
        }

        public Log AddLog(Log newLog)
        {
            newLog.StartTime = newLog.StartTime.ToUniversalTime();
            newLog.EndTime = newLog.EndTime.ToUniversalTime();
            context.Logs.Add(newLog);
            context.SaveChanges();
            return newLog;
        }

        public void DeleteTour(Tour tour)
        {
            context.Tours.Remove(tour);
            context.SaveChanges();
        }

        public void DeleteLog(Log log)
        {
            context.Logs.Remove(log);
            context.SaveChanges();
        }

        public Log UpdateLog(Log log)
        {
            var entity = context.Logs.Find(log.Id);
            if (entity == null)
            {
                throw new Exception("Log could not be edited as DataHandler.UpdateLog() didn't find a valid Log with the same Id");
            }

            context.Entry(entity).CurrentValues.SetValues(log);
            context.SaveChanges();
            return log;
        }

        public IEnumerable<Log> GetLogs(int tourId)
        {
            if (context.Logs.Where(t => t.TourId == tourId).Count() > 0)
            {
                return context.Logs.Where(t => t.TourId == tourId);
            }
            else
            {
                Debug.WriteLine($"No Tour with id {tourId} found");
                return new List<Log>();
            }
        }

        public IEnumerable<Tour> GetTours()
        {
            return context.Tours;
        }

        public Tour UpdateTour(Tour newTour)
        {
            var existingTour = context.Tours.Find(newTour.Id);
            if (existingTour != null)
            {
                // Detach the existing tracked entity
                context.Entry(existingTour).State = EntityState.Detached;
                // Attach the new instance and mark it as modified
                context.Tours.Update(newTour);
            }
            return newTour;
        }


        public IEnumerable<Tour> SearchTours(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return GetTours();

            return context.Tours
                .Where(t => EF.Functions.Like(t.Name, $"%{searchTerm}%")
                            || EF.Functions.Like(t.Description, $"%{searchTerm}%")
                            || EF.Functions.Like(t.Start, $"%{searchTerm}%")
                            || EF.Functions.Like(t.Destination, $"%{searchTerm}%"))
                .ToList();
        }

        public void SetImagePath(int id, string imagePath)
        {
            var tour = context.Tours.Find(id);
            if (tour != null)
            {
                tour.ImagePath = imagePath;
                context.SaveChanges();
                _logger.LogInformation($"Set Image-Path [path: {imagePath}] on tour [id: {id}]. {DateTime.UtcNow}");
            }
            else
            {
                _logger.LogWarning($"Could not set Image-Path [path: {imagePath}] on tour [id: {id}]. {DateTime.UtcNow}");
            }
        }

        public int GetLogCount(int id)
        {
            return context.Logs.Count(log => log.TourId == id);
        }

        public double GetAvgRating(int id)
        {
            try
            {
                return Math.Round(context.Logs.Where(log => log.TourId == id).Average(log => log.Rating), 2);
            }
            catch (InvalidOperationException)
            {
                _logger.LogWarning($"Invalid Cast Exception. No Logs for tour [id: {id}] have been found. Average Rating is set to 0. {DateTime.UtcNow}");
                return 0;
            }
        }

        public double GetAvgDifficulty(int id)
        {
            try
            {
                return Math.Round(context.Logs.Where(log => log.TourId == id).Average(log => log.Difficulty), 2);
            }
            catch (InvalidOperationException)
            {
                _logger.LogWarning($"Invalid Cast Exception. No Logs for tour [id: {id}] have been found. Average Difficulty is set to 0. {DateTime.UtcNow}");
                return 0;
            }
        }

        public int GetAvgDuration(int id)
        {
            try
            {
                var logs = context.Logs.Where(log => log.TourId == id).ToList();
                if (logs.Any())
                {
                    TimeSpan totalDuration = TimeSpan.Zero;
                    foreach (var log in logs)
                    {
                        totalDuration += log.EndTime - log.StartTime;
                    }
                    var averageDuration = totalDuration.TotalMinutes / logs.Count;
                    return (int)Math.Round(averageDuration);
                }
                else
                {
                    _logger.LogWarning($"No Logs found for tour [id: {id}]. Average Duration is set to 0. {DateTime.UtcNow}");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred while calculating average duration: {ex.Message}");
                throw;
            }
        }

    }
}
