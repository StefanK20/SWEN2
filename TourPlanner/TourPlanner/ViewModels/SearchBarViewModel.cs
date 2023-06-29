using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Extensions.Logging;
using TourPlanner.Models;
using TourPlanner.ViewModels.Interface;
using TourPlanner.ViewModels.Commands;
using TourPlanner.BL.Implementation;

namespace TourPlanner.ViewModels
{
    public class SearchBarViewModel : BaseViewModel
    {
		private readonly ILogger _logger;
		public ICommand SearchCommand { get; }
		public string SearchTerm { get; set; } = string.Empty;

        public SearchBarViewModel()
        {
            // Parameterless constructor logic
        }

        public SearchBarViewModel(ILogger logger, TourListViewModel tourListViewModel) {
			_logger = logger; 
			SearchCommand = new RelayCommand((_) => {
				tourListViewModel.Tours = new ObservableCollection<Tour>(SearchTours());
			});
		}

		public IEnumerable<Tour> SearchTours() {
			return ManagerFactory.GetTourManager(_logger).SearchTours(SearchTerm); 
		}
    }
}
