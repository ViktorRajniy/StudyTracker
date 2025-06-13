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
        /// Initialise instance of command.
        /// </summary>
        /// <param name="exercises">Data of user exercises.</param>
        public AddExerciseCommand(ObservableCollection<ExerciseViewModel> exercises)
        {
            Exercises = exercises;
        }

        /// <summary>
        /// Command action. Open AddExercise window and add exercise.
        /// If one of exercises selected - add exercise to children list.
        /// </summary>
        /// <param name="parameter">Selected exercise. Can be null.</param>
        public override void Execute(object? parameter)
        {
            AddExerciseWindowViewModel win;
            if (parameter != null || parameter is ExerciseViewModel)
            {
                var param = (ExerciseViewModel)parameter;
                win = new AddExerciseWindowViewModel();
                win.ShowDialog();
                if (win.View.DialogResult.Value)
                {
                    var newItem = win.Exercise;
                    param.Children.Add(newItem);
                    newItem.Parent = param;
                }
            }
            else
            {
                win = new AddExerciseWindowViewModel();
                win.ShowDialog();
                if (win.View.DialogResult.Value)
                {
                    Exercises.Add(win.Exercise);
                }
            }
        }
    }
}
