namespace StudyTracker.ViewModel.Commands
{
    using StudyTracker.ViewModel.ViewModels;
    using System.Collections.ObjectModel;
    using System.Windows;

    /// <summary>
    /// Delete exercise from collection of exercises.
    /// </summary>
    class DeleteExerciseCommand : CommandBase
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
        public DeleteExerciseCommand(ObservableCollection<ExerciseViewModel> exercises)
        {
            Exercises = exercises;
        }

        /// <summary>
        /// Return flag that show can command be execute.
        /// </summary>
        /// <param name="parameter">Command parameter.</param>
        /// <returns>Flag that show that command can be executed.</returns>
        public override bool CanExecute(object? parameter)
        {
            return parameter != null && parameter is ExerciseViewModel;
        }

        /// <summary>
        /// Command action. Delete selected exercise from exercise collection.
        /// </summary>
        /// <param name="parameter">Selected exercise.</param>
        public override void Execute(object? parameter)
        {
            if (parameter != null && parameter is ExerciseViewModel)
            {
                var itemToDelete = (ExerciseViewModel)parameter;
                if (itemToDelete.Children.Count != 0)
                {
                    MessageBox.Show("Can't delete this exercise. Delete sub-exercises before delete this exercise.");
                }
                else
                {
                    if (itemToDelete.Parent == null)
                    {
                        Exercises.Remove(itemToDelete);
                    }
                    else
                    {
                        var papa = itemToDelete.Parent;
                        papa.Children.Remove(itemToDelete);
                    }
                }
            }
        }
    }
}
