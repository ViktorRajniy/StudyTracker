namespace StudyTracker.ViewModel.ViewModels
{
    using StudyTracker.Stores;
    using StudyTracker.ViewModel.Commands;
    using StudyTracker.ViewModel.MVVM;
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
        /// Initialise instance of <see cref="MainViewModel"/>.
        /// </summary>
        /// <param name="navigationStore">Navigation store.</param>
        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            NavigeteTo = new NavigateMainFieldCommand(_navigationStore);
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
