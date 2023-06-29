using System;
using System.Windows.Input;
using Moq;
using NUnit.Framework;
using TourPlanner.Models;
using TourPlanner.ViewModels;
using TourPlanner.ViewModels.Commands;
using TourPlanner.ViewModels.Interface;

namespace TourPlanner.UnitTests.ViewModels
{
    [TestFixture]
    public class LogDialogViewModelTests
    {
        private LogDialogViewModel _logDialogViewModel;
        private Mock<LogListViewModel> _logListViewModelMock;
        private Mock<Action> _closeActionMock;

        [SetUp]
        public void SetUp()
        {
            _logListViewModelMock = new Mock<LogListViewModel>();
            _closeActionMock = new Mock<Action>();
            var selectedTour = new Tour { Name = "Test Tour" };
            var logToUpdate = new Log { Id = 1, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1) };

            _logDialogViewModel = new LogDialogViewModel(_logListViewModelMock.Object, selectedTour, logToUpdate, _closeActionMock.Object);
        }

        [Test]
        public void LogDialogViewModel_SetPropertiesForUpdate_LogDialogPropertiesSetCorrectly()
        {
            // Arrange
            var expectedStartTime = DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss");
            var expectedEndTime = DateTime.Now.AddHours(1).ToString("dd MMMM yyyy"+" HH:mm:ss");
            var expectedHeading = $"Edit log for \"{_logDialogViewModel.SelectedTour.Name}\"";

            // Assert
            Assert.AreEqual(1, _logDialogViewModel.LogDialogLogId);
            Assert.AreEqual(expectedStartTime, _logDialogViewModel.LogDialogStartDateTime);
            Assert.AreEqual(expectedEndTime, _logDialogViewModel.LogDialogEndDateTime);
            Assert.IsTrue(string.IsNullOrEmpty(_logDialogViewModel.LogDialogComment));
            Assert.AreEqual(0, _logDialogViewModel.LogDialogDifficulty);
            Assert.AreEqual(0, _logDialogViewModel.LogDialogRating);
            Assert.AreEqual(expectedHeading, _logDialogViewModel.LogDialogHeading);

        }


        [Test]
        public void LogDialogViewModel_SetPropertiesForNewLog_LogDialogPropertiesSetCorrectly()
        {
            // Arrange
            var selectedTour = new Tour { Name = "Test Tour" };
            Log logToUpdate = null;

            // Act
            _logDialogViewModel = new LogDialogViewModel(_logListViewModelMock.Object, selectedTour, logToUpdate, _closeActionMock.Object);

            // Assert
            Assert.AreEqual(0, _logDialogViewModel.LogDialogLogId);
            Assert.AreEqual("", _logDialogViewModel.LogDialogStartDateTime);
            Assert.AreEqual("", _logDialogViewModel.LogDialogEndDateTime);
            Assert.AreEqual("", _logDialogViewModel.LogDialogComment);
            Assert.AreEqual(0, _logDialogViewModel.LogDialogDifficulty);
            Assert.AreEqual(0, _logDialogViewModel.LogDialogRating);
            Assert.AreEqual($"Create a new log for \"{_logDialogViewModel.SelectedTour.Name}\"", _logDialogViewModel.LogDialogHeading);
        }

    }
}
