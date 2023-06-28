using Microsoft.Extensions.Logging;
using Moq;
using TourPlanner.BL.Implementation;
using TourPlanner.DAL.Interface.SQL;
using TourPlanner.Models;

namespace TourPlanner.Tests
{
    public class LogManagerTests
    {
        private LogManager _manager;
        private readonly Mock<IDataHandler> _handlerMock = new Mock<IDataHandler>();
        private readonly Log _log = new Log(0, DateTime.Now, DateTime.Now, 100, "Start", "Destination", "Comment", 5, 5);
        private readonly Log _log2 = new Log(9, 0, DateTime.Now, DateTime.Now, 300, "Start", "Destination", "Comment2", 1, 10);
        private readonly Log _fullLog = new Log(10, DateTime.Now, DateTime.Now, 100, "Start", "Destination", "Comment", 5, 5);
        private readonly Log _updatedFullLog = new Log(10, DateTime.Now, DateTime.Now, 100, "Start", "Destination", "Updated", 6, 6);

        [SetUp]
        public void Setup()
        {
            _handlerMock.Setup(handler => handler.AddLog(_log)).Returns(_fullLog);
            _handlerMock.Setup(handler => handler.UpdateLog(_fullLog)).Returns(_updatedFullLog);
            _handlerMock.Setup(handler => handler.GetLogs(0)).Returns(new List<Log> { _log, _log2 });
            _handlerMock.Setup(handler => handler.DeleteLog(_fullLog));

            _manager = new LogManager((ILogger)_handlerMock.Object);
        }

        [Test]
        public void TestCreateLog_ReturnsFullLogObject()
        {
            var result = _manager.CreateLog(_log);
            Assert.AreEqual(_fullLog, result);
            _handlerMock.Verify(handler => handler.AddLog(_log), Times.Once);
        }

        [Test]
        public void TestGetLogs_ReturnsLogList()
        {
            var result = _manager.GetLogs(0);
            Assert.AreEqual(2, result.Count());
            _handlerMock.Verify(handler => handler.GetLogs(0), Times.Once);
        }

        [Test]
        public void TestUpdateLog_ReturnsUpdatedLogObject()
        {
            var result = _manager.UpdateLog(_fullLog);
            Assert.AreEqual(_updatedFullLog, result);
            _handlerMock.Verify(handler => handler.UpdateLog(_fullLog), Times.Once);
        }

        [Test]
        public void TestDeleteLog_CallsDeleteLogMethod()
        {
            _manager.DeleteLog(10);
            _handlerMock.Verify(handler => handler.DeleteLog(_fullLog), Times.Once);
        }

        [Test]
        public void TestDeleteLog_DoesNotCallDeleteLogMethod()
        {
            _manager.DeleteLog(11);
            _handlerMock.Verify(handler => handler.DeleteLog(_fullLog), Times.Never);
        }
    }
}