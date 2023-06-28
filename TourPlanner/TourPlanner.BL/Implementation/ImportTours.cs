using System;
using System.IO;
using System.Windows;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using Newtonsoft.Json;
using TourPlanner.DAL.Config;
using TourPlanner.DAL.Implementation.SQL;
using TourPlanner.DAL.SQL;
using TourPlanner.Models.Json;

namespace TourPlanner.BL.Implementation
{
    public class ImportTours
    {
        private readonly ILogger _logger;

        public ImportTours(ILogger logger)
        {
            _logger = logger;
        }

        public string ChooseImportFile()
        {
            var openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Path.Combine(Directory.GetCurrentDirectory(), ConfigManager.GetConfig().ExportLocation),
                Filter = "json files (*.json)|*.json"
            };
            openFileDialog.ShowDialog();
            return openFileDialog.FileName;
        }

        public void Import()
        {
            var file = ChooseImportFile();
            if (string.IsNullOrEmpty(file))
            {
                _logger.LogWarning($"No valid import file chosen. {DateTime.UtcNow}");
                MessageBox.Show($"No import file chosen.", "No Import File", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            var handler = new DataHandler(_logger);

            var importFile = File.ReadAllText(file);
            var tourObjectList = JsonConvert.DeserializeObject<TourObjectCollection>(importFile);

            foreach (var tourObject in tourObjectList.TourObjects)
            {
                var newTour = handler.AddTour(tourObject.Tour);
                newTour.ImagePath = Path.Combine(ConfigManager.GetConfig().ImageLocation!, $"{newTour.Id}.png");
                handler.SetImagePath(newTour.Id, newTour.ImagePath);

                var imageBytes = Convert.FromBase64String(tourObject.ImageInBase64);
                File.WriteAllBytesAsync(newTour.ImagePath, imageBytes);
                foreach (var log in tourObject.Logs)
                {
                    log.TourId = newTour.Id;
                    handler.AddLog(log);
                }
            }
        }
    }
}