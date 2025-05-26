namespace StudyTracker.Stores
{
    using StudyTracker.ViewModel.MVVM;

    /// <summary>
    /// Store of navigation.
    /// </summary>
    public class NavigationStore
    {
        /// <summary>
        /// Current viewModel of main part of the window.
        /// </summary>
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        /// <summary>
        /// Action of CurrentViewModel changed.
        /// </summary>
        public event Action CurrentViewModelChanged;

        /// <summary>
        /// Event of CurrentViewModel changed.
        /// </summary>
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
