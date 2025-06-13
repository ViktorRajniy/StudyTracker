namespace StudyTracker.ViewModel.Commands
{
    using StudyTracker.ViewModel.ViewModels;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Edit exercise in collection of exercises.
    /// </summary>
    class EditExerciseCommand : CommandBase
    {
        /// <summary>
        /// Instance of user exercises.
        /// </summary>
        private ObservableCollection<ExerciseViewModel> _exercises = new();
        public ObservableCollection<ExerciseViewModel> Exercises
        {
            get { return _exercises; }
            set { _exercises = value; }
        }

        /// <summary>
        /// Initialise instance of command.
        /// </summary>
        /// <param name="exercises">Data of user exercises.</param>
        public EditExerciseCommand(ObservableCollection<ExerciseViewModel> exercises)
        {
            Exercises = exercises;
        }

        /// <summary>
        /// Command action. Open EditExercise window and edit exercise in collection.
        /// </summary>
        /// <param name="parameter">Exercise to edit.</param>
        public override void Execute(object? parameter)
        {
            if (parameter != null || parameter is ExerciseViewModel)
            {
                var param = (ExerciseViewModel)parameter;
                var win = new EditExerciseWindowViewModel(param);
                win.ShowDialog();
                if (win.View.DialogResult.Value)
                {
                    var oldExercise = Exercises.FirstOrDefault(e => e.CreationTime == win.Exercise.CreationTime);
                    oldExercise = win.Exercise;
                }                
            }
        }
    }
}
