namespace StudyTracker.ViewModel.ViewModels
{
    using StudyTracker.ViewModel.Commands;
    using StudyTracker.ViewModel.MVVM;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    public class MenuViewModel: ViewModelBase
    {
        /// <summary>
        /// Collection of all exercises.
        /// </summary>
        private ObservableCollection<ExerciseViewModel> _exercises = new();
        public ObservableCollection<ExerciseViewModel> Exercises
        {
            get { return _exercises; }
            set { _exercises = value; }
        }

        /// <summary>
        /// Command to add exercise.
        /// </summary>
        public ICommand AddExercise { get; }

        public MenuViewModel(ObservableCollection<ExerciseViewModel> exercises)
        {
            AddExercise = new AddExerciseCommand(exercises);
        }
    }
}
