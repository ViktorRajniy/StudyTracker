namespace StudyTracker.ViewModel.MVVM
{
    using System.ComponentModel;

    /// <summary>
    /// Base class for viewModels.
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Change event.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Property changed action.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
