using NUnit.Framework;
using TourPlanner.Models;

namespace TourPlanner.Tests.Models
{
    [TestFixture]
    public class TourTests
    {
        [Test]
        public void Constructor_WithValidParameters_PropertiesAreSet()
        {
            // Arrange
            int id = 1;
            string name = "Tour 1";
            string description = "Test tour";
            string start = "City A";
            string destination = "City B";
            TransportType transportType = TransportType.Car;
            double distance = 100.5;
            int estimatedTime = 3600;
            string imagePath = "path/to/image.jpg";
            double popularity = 4.5;
            double childFriendliness = 3.8;
            string displayDistance = "100.5 km";
            string displayTime = "1:00:00";
            byte[] routeImageSource = new byte[] { 0x00, 0x01, 0x02 };

            // Act
            var tour = new Tour(id, name, description, start, destination, transportType, distance, estimatedTime,
                imagePath, popularity, childFriendliness, displayDistance, displayTime, routeImageSource);

            // Assert
            Assert.AreEqual(id, tour.Id);
            Assert.AreEqual(name, tour.Name);
            Assert.AreEqual(description, tour.Description);
            Assert.AreEqual(start, tour.Start);
            Assert.AreEqual(destination, tour.Destination);
            Assert.AreEqual(transportType, tour.TransportType);
            Assert.AreEqual(distance, tour.Distance);
            Assert.AreEqual(estimatedTime, tour.EstimatedTime);
            Assert.AreEqual(imagePath, tour.ImagePath);
            Assert.AreEqual(popularity, tour.Popularity);
            Assert.AreEqual(childFriendliness, tour.ChildFriendliness);
            Assert.AreEqual(displayDistance, tour.DisplayDistance);
            Assert.AreEqual(displayTime, tour.DisplayTime);
            Assert.AreEqual(routeImageSource, tour.RouteImageSource);
        }

        [Test]
        public void Constructor_WithDefaultParameters_PropertiesAreSetToDefaults()
        {
            // Arrange
            var tour = new Tour();

            // Assert
            Assert.AreEqual(0, tour.Id);
            Assert.IsNull(tour.Name);
            Assert.IsNull(tour.Description);
            Assert.IsNull(tour.Start);
            Assert.IsNull(tour.Destination);
            Assert.AreEqual(TransportType.Car, tour.TransportType);
            Assert.AreEqual(0.0, tour.Distance);
            Assert.AreEqual(0, tour.EstimatedTime);
            Assert.IsNull(tour.ImagePath);
            Assert.AreEqual(0.0, tour.Popularity);
            Assert.AreEqual(0.0, tour.ChildFriendliness);
            Assert.AreEqual("0 km", tour.DisplayDistance);
            Assert.AreEqual("0:00:00:00", tour.DisplayTime);
            Assert.IsNull(tour.RouteImageSource);
        }
    }
}
