using TourPlanner.ViewModels.Interface;

namespace TourPlanner.ViewModels
{
	public class TourDetailsViewModel : BaseViewModel
    {
        public TourListViewModel TourListViewModel { get; }
        public TourDetailsViewModel() { }   
        public TourDetailsViewModel(TourListViewModel tourListViewModel) {
	        TourListViewModel = tourListViewModel;
        }
    }
}
