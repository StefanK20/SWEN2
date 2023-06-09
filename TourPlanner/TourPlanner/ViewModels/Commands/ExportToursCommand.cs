﻿using Microsoft.Extensions.Logging;
using TourPlanner.BL.Implementation;
using TourPlanner.ViewModels.Interface;

namespace TourPlanner.ViewModels.Commands
{
    public class ExportToursCommand : BaseCommand
    {
        private readonly ILogger _logger;

        public ExportToursCommand(ILogger logger) {
            _logger = logger;
        }

        public override void Execute(object? parameter) {
            var exportTours = new ExportTours(_logger);
            exportTours.Export();
        }
    }
}
