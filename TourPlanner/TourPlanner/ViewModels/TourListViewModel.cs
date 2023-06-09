﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Extensions.Logging;
using TourPlanner.Models;
using TourPlanner.Helper;
using TourPlanner.ViewModels.Interface;
using TourPlanner.ViewModels.Commands;
using TourPlanner.Views;
using TourPlanner.BL.Implementation;
using System.Transactions;
using System;

namespace TourPlanner.ViewModels
{
    public class TourListViewModel : BaseViewModel {

		private readonly ILogger _logger; 

		public ICommand AddTourDialogCommand { get; }
		public ICommand EditTourDialogCommand { get; set; }
		public ICommand DeleteTourCommand { get; }
		public ICommand SwapDirectionCommand { get; }

		private ObservableCollection<Tour> _tours;
		public ObservableCollection<Tour> Tours {
			get => _tours;
			set {
				_tours = value;
				OnPropertyChanged(nameof(Tours));
				SelectedTour = _tours.FirstOrDefault()!; 
			} 
		}

		public LogListViewModel LogListViewModel { get; set; }

		private Tour _selectedTour = null!;
		public Tour SelectedTour {
			get => _selectedTour;
			set {
				_selectedTour = value ?? new Tour("No tour selected."); 
				OnPropertyChanged(nameof(SelectedTour));

				// Cache Image to byte-array property of tour in order to be able to close file descriptor 
				if (_selectedTour.ImagePath is not null) {
					var path = Path.Combine(Directory.GetCurrentDirectory(), _selectedTour.ImagePath);
					using (FileStream stream = File.Open(path, FileMode.Open)) {
						_selectedTour.RouteImageSource = stream.ReadFully(); // Stream to byte-array, function in Helper/ViewModelHelper.cs
					}
					OnPropertyChanged(nameof(SelectedTour));
				}

				// Update EditTourDialogCommand to edit selected tour
				EditTourDialogCommand = new OpenEditTourDialogCommand(this);
				OnPropertyChanged(nameof(EditTourDialogCommand));

				// Update LogListView with Logs of current SelectedTour
				LogListViewModel.UpdateView(SelectedTour); 
			}
		}

        /// <summary>
        /// Constructor for TourListViewModel, Gets tours from database and initializes commands
        /// </summary>

        public TourListViewModel()
        {
            // Parameterless constructor logic
        }

        public TourListViewModel(ILogger logger, LogListViewModel logListViewModel) {
			_logger = logger; 
			LogListViewModel = logListViewModel;

			Tours = new ObservableCollection<Tour>(GetTours());
			SelectedTour = Tours.FirstOrDefault()!;

			AddTourDialogCommand = new RelayCommand((_) => {
				var dialog = new TourDialog(this);
				dialog.ShowDialog();
			});
			EditTourDialogCommand = new OpenEditTourDialogCommand(this);
			DeleteTourCommand = new DeleteTourCommand(this);

			// Unique feature: quickly swap start and destination from specific tour 
			SwapDirectionCommand = new RelayCommand(async (_) => {
				if (!IsEmpty()) {
					(SelectedTour.Start, SelectedTour.Destination) = (SelectedTour.Destination, SelectedTour.Start);
					OnPropertyChanged(nameof(SelectedTour));
                    // save changes
                    await GetUpdatedTour(SelectedTour);
				}
			}); 
		}

		public bool IsEmpty() {
			return Tours.Count <= 0; 
		}

		public void AddTour(Tour tour) {
			Tours.Add(tour);
		}
		 
		public void RemoveSelectedTour() {
			var toRemove = SelectedTour;
            Tours.Remove(toRemove);
            if (!IsEmpty()) {
                SelectedTour = Tours.FirstOrDefault()!;
            }
		}

		public void ReplaceTour(Tour tour) {
			var t = Tours.FirstOrDefault(t => t.Id == tour.Id);
			Tours[Tours.IndexOf(t)] = tour;
			SelectedTour = tour; 
		}

		public IEnumerable<Tour> GetTours() {
			return ManagerFactory.GetTourManager(_logger).GetTours(); 
		}

		public bool DeleteTour() {
			// Delete Route Image
			if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), SelectedTour.ImagePath))) {
				File.Delete(Path.Combine(Directory.GetCurrentDirectory(), SelectedTour.ImagePath));
			}
            try
            {
                ManagerFactory.GetTourManager(_logger).DeleteTour(SelectedTour);
                // Deletion succeeded
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to delete tour: {ex.Message}");
                // Deletion failed
                return false;
            }
        }

		public async Task<Tour> GetCreatedTour(Tour tour) {
			return await ManagerFactory.GetTourManager(_logger).CreateTour(tour);
		}

		public async Task<Tour> GetUpdatedTour(Tour tour) {
			return await ManagerFactory.GetTourManager(_logger).UpdateTour(tour);
		}
	}
}
