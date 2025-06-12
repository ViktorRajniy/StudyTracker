using StudyTracker.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudyTracker.ViewModel.Commands
{
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
        /// Initialise instancec of command.
        /// </summary>
        /// <param name="exercises">Data of user exercises.</param>
        public DeleteExerciseCommand(ObservableCollection<ExerciseViewModel> exercises)
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
