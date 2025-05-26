namespace StudyTracker.ViewModel.ViewModels
{
    using StudyTracker.ViewModel.MVVM;
    using System.Windows.Input;

    /// <summary>
    /// DataContext of side panel.
    /// </summary>
    class SidePanelViewModel: ViewModelBase
    {
        /// <summary>
        /// Command that change main field of window.
        /// </summary>
        public ICommand NavigeteTo { get; }

        /// <summary>
        /// Initialise instance of <see cref="SidePanelViewModel"/>.
        /// </summary>
        /// <param name="Navigate">Command that change main field of window.</param>
        public SidePanelViewModel(ICommand Navigate)
        {
            NavigeteTo = Navigate;
        }
    }
}
