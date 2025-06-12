using StudyTracker.ViewModel.MVVM;
using StudyTracker.ViewModel.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace StudyTracker.ViewModel.Commands
{
    class EditExerciseCommand: CommandBase
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
        /// Initialise instancec of command.
        /// </summary>
        /// <param name="exercises">Data of user exercises.</param>
        public EditExerciseCommand(ObservableCollection<ExerciseViewModel> exercises)
        {
            Exercises = exercises;
        }

        /// <summary>
        /// Command action. Open AddExercise window and add exercise.
        /// </summary>
        /// <param name="parameter">Command parameter.</param>
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
