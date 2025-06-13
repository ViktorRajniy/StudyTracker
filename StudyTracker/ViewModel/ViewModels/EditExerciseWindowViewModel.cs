namespace StudyTracker.ViewModel.ViewModels
{
    using StudyTracker.View;
    using StudyTracker.ViewModel.MVVM;

    /// <summary>
    /// View model of Edit exercise window.
    /// </summary>
    public class EditExerciseWindowViewModel : BaseWindowViewModel<EditExerciseWindow>
    {
        /// <summary>
        /// Data of exercise that creating.
        /// </summary>
        private ExerciseViewModel _exercise;
        public ExerciseViewModel Exercise
        {
            get { return _exercise; }
            set { _exercise = value; OnPropertyChanged(nameof(Exercise)); }
        }

        /// <summary>
        /// Initialise instance of class.
        /// </summary>
        /// <param name="exercise">Instancec of exercise.</param>
        public EditExerciseWindowViewModel(ExerciseViewModel exercise)
        {
            Exercise = exercise;
        }
    }
}
