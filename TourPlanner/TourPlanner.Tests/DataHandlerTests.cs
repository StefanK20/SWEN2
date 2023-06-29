using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TourPlanner.DAL.Implementation.SQL;
using TourPlanner.DAL.Interface.SQL;
using TourPlanner.DAL.SQL;
using TourPlanner.Models;

namespace TourPlanner.UnitTests.DAL.Implementation.SQL
{
    [TestFixture]
    public class DataHandlerTests
    {
        private DataHandler _dataHandler;
        private Mock<ILogger<DataHandler>> _loggerMock;
        private Mock<TourPlannerContext> _contextMock;

        [SetUp]
        public void SetUp()
        {
            _loggerMock = new Mock<ILogger<DataHandler>>();
            _contextMock = new Mock<TourPlannerContext>();
            _dataHandler = new DataHandler(_loggerMock.Object, _contextMock.Object);
        }

        [Test]
        public void AddTour_ShouldAddTourToDatabase()
        {
            // Arrange
            var tour = new Tour { Name = "Test Tour" };

            // Act
            var result = _dataHandler.AddTour(tour);

            // Assert
            Assert.AreEqual(tour, result);
            // Add additional assertions or verifications as needed
        }
    }
}
