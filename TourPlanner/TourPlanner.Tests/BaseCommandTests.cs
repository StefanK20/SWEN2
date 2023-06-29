using NUnit.Framework;
using TourPlanner.ViewModels.Interface;

namespace TourPlanner.UnitTests.ViewModels
{
    [TestFixture]
    public class BaseCommandTests
    {
        [Test]
        public void CanExecute_WithNullPredicate_ReturnsTrue()
        {
            // Arrange
            var command = new TestCommand();

            // Act
            var canExecute = command.CanExecute(null);

            // Assert
            Assert.IsTrue(canExecute);
        }

        [Test]
        public void Execute_CallsExecuteMethod()
        {
            // Arrange
            var command = new TestCommand();
            var executed = false;
            command.ExecuteAction = _ => executed = true;

            // Act
            command.Execute(null);

            // Assert
            Assert.IsTrue(executed);
        }

        private class TestCommand : BaseCommand
        {
            public Action<object?>? ExecuteAction { get; set; }

            public override void Execute(object? parameter)
            {
                ExecuteAction?.Invoke(parameter);
            }
        }
    }
}
