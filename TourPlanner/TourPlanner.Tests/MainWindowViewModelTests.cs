using Moq;
using TourPlanner.ViewModels;

namespace TourPlanner.Tests
{
    public class MainWindowViewModelTests
    {
        [Test]
        public void Constructor_InitializesViewModels()
        {
            // Arrange
            var searchBarViewModelMock = new Mock<SearchBarViewModel>();
            var menuStripViewModelMock = new Mock<MenuStripViewModel>();
            var tourListViewModelMock = new Mock<TourListViewModel>();
            var tourDetailsViewModelMock = new Mock<TourDetailsViewModel>();
            var logListViewModelMock = new Mock<LogListViewModel>();

            // Configure mock behavior if necessary

            var mainWindowViewModel = new MainWindowViewModel(
                searchBarViewModelMock.Object,
                menuStripViewModelMock.Object,
                tourListViewModelMock.Object,
                tourDetailsViewModelMock.Object,
                logListViewModelMock.Object
            );

            // Assert
            Assert.That(mainWindowViewModel.SearchBarViewModel, Is.Not.Null);
            Assert.That(mainWindowViewModel.MenuStripViewModel, Is.Not.Null);
            Assert.That(mainWindowViewModel.TourListViewModel, Is.Not.Null);
            Assert.That(mainWindowViewModel.TourDetailsViewModel, Is.Not.Null);
            Assert.That(mainWindowViewModel.LogListViewModel, Is.Not.Null);

            Assert.That(mainWindowViewModel.SearchBarViewModel, Is.EqualTo(searchBarViewModelMock.Object));
            Assert.That(mainWindowViewModel.MenuStripViewModel, Is.EqualTo(menuStripViewModelMock.Object));
            Assert.That(mainWindowViewModel.TourListViewModel, Is.EqualTo(tourListViewModelMock.Object));
            Assert.That(mainWindowViewModel.TourDetailsViewModel, Is.EqualTo(tourDetailsViewModelMock.Object));
            Assert.That(mainWindowViewModel.LogListViewModel, Is.EqualTo(logListViewModelMock.Object));
        }

        [Test]
        public void Constructor_InitializesSearchBarViewModel()
        {
            // Arrange
            var searchBarViewModelMock = new Mock<SearchBarViewModel>();
            var menuStripViewModelMock = new Mock<MenuStripViewModel>();
            var tourListViewModelMock = new Mock<TourListViewModel>();
            var tourDetailsViewModelMock = new Mock<TourDetailsViewModel>();
            var logListViewModelMock = new Mock<LogListViewModel>();

            // Act
            var mainWindowViewModel = new MainWindowViewModel(
                searchBarViewModelMock.Object,
                menuStripViewModelMock.Object,
                tourListViewModelMock.Object,
                tourDetailsViewModelMock.Object,
                logListViewModelMock.Object
            );

            // Assert
            Assert.That(mainWindowViewModel.SearchBarViewModel, Is.EqualTo(searchBarViewModelMock.Object));
        }

        [Test]
        public void Constructor_InitializesMenuStripViewModel()
        {
            // Arrange
            var searchBarViewModelMock = new Mock<SearchBarViewModel>();
            var menuStripViewModelMock = new Mock<MenuStripViewModel>();
            var tourListViewModelMock = new Mock<TourListViewModel>();
            var tourDetailsViewModelMock = new Mock<TourDetailsViewModel>();
            var logListViewModelMock = new Mock<LogListViewModel>();

            // Act
            var mainWindowViewModel = new MainWindowViewModel(
                searchBarViewModelMock.Object,
                menuStripViewModelMock.Object,
                tourListViewModelMock.Object,
                tourDetailsViewModelMock.Object,
                logListViewModelMock.Object
            );

            // Assert
            Assert.That(mainWindowViewModel.MenuStripViewModel, Is.EqualTo(menuStripViewModelMock.Object));
        }

        [Test]
        public void Constructor_InitializesTourListViewModel()
        {
            // Arrange
            var searchBarViewModelMock = new Mock<SearchBarViewModel>();
            var menuStripViewModelMock = new Mock<MenuStripViewModel>();
            var tourListViewModelMock = new Mock<TourListViewModel>();
            var tourDetailsViewModelMock = new Mock<TourDetailsViewModel>();
            var logListViewModelMock = new Mock<LogListViewModel>();

            // Act
            var mainWindowViewModel = new MainWindowViewModel(
                searchBarViewModelMock.Object,
                menuStripViewModelMock.Object,
                tourListViewModelMock.Object,
                tourDetailsViewModelMock.Object,
                logListViewModelMock.Object
            );

            // Assert
            Assert.That(mainWindowViewModel.TourListViewModel, Is.EqualTo(tourListViewModelMock.Object));
        }
    }
}