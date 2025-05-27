namespace StudyTracker.ViewModel.ViewModels
{
    using StudyTracker.ViewModel.Commands;
    using StudyTracker.ViewModel.MVVM;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    /// <summary>
    /// Data context of list of all user exercises.
    /// </summary>
    class BacklogViewModel : ViewModelBase
    {
        /// <summary>
        /// Collection of all exercises.
        /// </summary>
        private ObservableCollection<ExerciseViewModel> _exercises = new ObservableCollection<ExerciseViewModel>();
        public ObservableCollection<ExerciseViewModel> Exercises
        {
            get { return _exercises; }
            set { _exercises = value; }
        }

        /// <summary>
        /// Command to add exercise.
        /// </summary>
        public ICommand AddExercise { get; }

        /// <summary>
        /// Initialise instance of <see cref="BacklogViewModel"/>.
        /// </summary>
        public BacklogViewModel(ObservableCollection<ExerciseViewModel> exercises)
        {
            Exercises = exercises; 
            AddExercise = new AddExerciseCommand(exercises);
        }
    }
}
