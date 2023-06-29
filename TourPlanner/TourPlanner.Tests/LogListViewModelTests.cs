using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TourPlanner.BL.Implementation;
using TourPlanner.BL.Interface;
using TourPlanner.Models;
using TourPlanner.ViewModels;
using TourPlanner.ViewModels.Commands;
using TourPlanner.ViewModels.Interface;

namespace TourPlanner.Tests.ViewModels
{
    [TestFixture]
    public class LogListViewModelTests
    {
        private LogListViewModel _viewModel;
        private Mock<ILogger> _loggerMock;

        [SetUp]
        public void SetUp()
        {
            _loggerMock = new Mock<ILogger>();

            _viewModel = new LogListViewModel(_loggerMock);
        }

        [Test]
        public void UpdateView_SelectedTourIsNull_ShouldNotChangeProperties()
        {
            // Act
            _viewModel.UpdateView(null);

            // Assert
            Assert.IsNull(_viewModel.SelectedTour);
            Assert.IsNull(_viewModel.AddLogDialogCommand);
            Assert.IsEmpty(_viewModel.Logs);
            Assert.IsNull(_viewModel.SelectedLog);
            Assert.AreEqual("Logs", _viewModel.LogListHeading);
            Assert.IsNull(_viewModel.EditLogDialogCommand);
        }


        [Test]
        public void IsEmpty_LogsIsEmpty_ShouldReturnTrue()
        {
            // Arrange
            _viewModel.Logs = new ObservableCollection<Log>();

            // Act
            bool isEmpty = _viewModel.IsEmpty();

            // Assert
            Assert.IsTrue(isEmpty);
        }

        [Test]
        public void IsEmpty_LogsIsNotEmpty_ShouldReturnFalse()
        {
            // Arrange
            _viewModel.Logs = new ObservableCollection<Log> { new Log { Id = 1, TourId = 1} };

            // Act
            bool isEmpty = _viewModel.IsEmpty();

            // Assert
            Assert.IsFalse(isEmpty);
        }

        [Test]
        public void AddLog_ShouldAddLogToLogsAndSetSelectedLog()
        {
            // Arrange
            var log = new Log { Id = 1, TourId = 1};

            // Act
            _viewModel.AddLog(log);

            // Assert
            Assert.AreEqual(1, _viewModel.Logs.Count);
            Assert.AreSame(log, _viewModel.Logs[0]);
            Assert.AreSame(log, _viewModel.SelectedLog);
        }

        [Test]
        public void RemoveSelectedLog_LogsIsNotEmpty_ShouldRemoveSelectedLogAndSetNewSelectedLog()
        {
            // Arrange
            var log1 = new Log { Id = 1, TourId = 1};
            var log2 = new Log { Id = 2, TourId = 1};
            _viewModel.Logs = new ObservableCollection<Log> { log1, log2 };
            _viewModel.SelectedLog = log1;

            // Act
            _viewModel.RemoveSelectedLog();

            // Assert
            Assert.AreEqual(1, _viewModel.Logs.Count);
            Assert.AreSame(log2, _viewModel.Logs[0]);
            Assert.AreSame(log2, _viewModel.SelectedLog);
        }

        [Test]
        public void RemoveSelectedLog_LogsIsEmpty_ShouldNotChangeProperties()
        {
            // Arrange
            _viewModel.Logs = new ObservableCollection<Log>();

            // Act
            _viewModel.RemoveSelectedLog();

            // Assert
            Assert.IsEmpty(_viewModel.Logs);
            Assert.IsNull(_viewModel.SelectedLog);
        }

        [Test]
        public void UpdateView_SelectedTourIsNotNull_ShouldChangeProperties()
        {
            // Arrange
            var tour = new Tour { Id = 1, Name = "Test Tour" };

            // Act
            _viewModel.UpdateView(tour);

            // Assert
            Assert.AreSame(tour, _viewModel.SelectedTour);
            Assert.IsNotNull(_viewModel.AddLogDialogCommand);
            Assert.IsNotNull(_viewModel.Logs);
            Assert.IsEmpty(_viewModel.Logs);
            Assert.IsNull(_viewModel.SelectedLog);
            Assert.AreEqual($"Logs for \"{tour.Name}\"", _viewModel.LogListHeading);
            Assert.IsNotNull(_viewModel.EditLogDialogCommand);
        }

        [Test]
        public void RemoveSelectedLog_SelectedLogIsNull_ShouldNotChangeProperties()
        {
            // Arrange
            _viewModel.Logs = new ObservableCollection<Log>();
            _viewModel.SelectedLog = null;

            // Act
            _viewModel.RemoveSelectedLog();

            // Assert
            Assert.IsEmpty(_viewModel.Logs);
            Assert.IsNull(_viewModel.SelectedLog);
        }

        [Test]
        public void ClearLogs_ShouldRemoveAllLogsAndSetSelectedLogToNull()
        {
            // Arrange
            var log1 = new Log { Id = 1, TourId = 1 };
            var log2 = new Log { Id = 2, TourId = 1 };
            _viewModel.Logs = new ObservableCollection<Log> { log1, log2 };
            _viewModel.SelectedLog = log1;

            // Act
            while (_viewModel.Logs.Any())
            {
                _viewModel.RemoveSelectedLog();
            }

            // Assert
            Assert.IsEmpty(_viewModel.Logs);
            Assert.IsNull(_viewModel.SelectedLog);
        }

    }
    }
