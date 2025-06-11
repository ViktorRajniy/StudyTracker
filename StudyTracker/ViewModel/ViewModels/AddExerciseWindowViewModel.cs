namespace StudyTracker.ViewModel.ViewModels
{
    using StudyTracker.View;
    using StudyTracker.ViewModel.MVVM;

    /// <summary>
    /// View model of Add exercise window.
    /// </summary>
    public class AddExerciseWindowViewModel : BaseWindowViewModel<AddExerciseWindow>
    {
        /// <summary>
        /// Data of exercise that creating.
        /// </summary>
        private ExerciseViewModel _exercise = new("New laboratory work");
        public ExerciseViewModel Exercise
        {
            get { return _exercise; }
            set { _exercise = value; OnPropertyChanged(nameof(Exercise)); }
        }
    }
}
