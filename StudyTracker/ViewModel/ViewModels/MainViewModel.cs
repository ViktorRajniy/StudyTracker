namespace StudyTracker.ViewModel.ViewModels
{
    using StudyTracker.Stores;
    using StudyTracker.ViewModel.Commands;
    using StudyTracker.ViewModel.MVVM;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    /// <summary>
    /// Data context of main window.
    /// </summary>
    class MainViewModel: BaseWindowViewModel<MainWindow>
    {
        /// <summary>
        /// Navigation store.
        /// </summary>
        private readonly NavigationStore _navigationStore;

        /// <summary>
        /// Instance of current view model of main field of window.
        /// </summary>
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        /// <summary>
        /// Command that change main field of window.
        /// </summary>
        public ICommand NavigeteTo { get; }

        /// <summary>
        /// Data of user exercises.
        /// </summary>
        private ObservableCollection<ExerciseViewModel> _exercises = new ObservableCollection<ExerciseViewModel>();

        /// <summary>
        /// Initialise instance of <see cref="MainViewModel"/>.
        /// </summary>
        /// <param name="navigationStore">Navigation store.</param>
        public MainViewModel(NavigationStore navigationStore, ObservableCollection<ExerciseViewModel> exercises)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _exercises = exercises;
            NavigeteTo = new NavigateMainFieldCommand(_navigationStore, _exercises);
        }

        /// <summary>
        /// Action to change main field of window.
        /// </summary>
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
