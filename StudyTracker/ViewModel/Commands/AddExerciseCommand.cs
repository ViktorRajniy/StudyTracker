namespace StudyTracker.ViewModel.Commands
{
    using StudyTracker.ViewModel.ViewModels;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Add exercise to collection of exercises.
    /// </summary>
    class AddExerciseCommand : CommandBase
    {
        /// <summary>
        /// Instance of user exercises.
        /// </summary>
        private ObservableCollection<ExerciseViewModel> _exercises = new ObservableCollection<ExerciseViewModel>();
        public ObservableCollection<ExerciseViewModel> Exercises
        {
            get { return _exercises; }
            set { _exercises = value; }
        }

        /// <summary>
        /// Initialise instancec of command.
        /// </summary>
        /// <param name="exercises">Data of user exercises.</param>
        public AddExerciseCommand(ObservableCollection<ExerciseViewModel> exercises)
        {
            Exercises = exercises;
        }

        /// <summary>
        /// Command action. Open AddExercise window and add exercise.
        /// </summary>
        /// <param name="parameter">Command parameter.</param>
        public override void Execute(object? parameter)
        {
            var exerciseWindow = new AddExerciseWindowViewModel();
            exerciseWindow.ShowDialog();
            if (exerciseWindow.View.DialogResult.Value)
            {
                Exercises.Add(exerciseWindow.Exercise);
            }
        }
    }
}
