namespace StudyTracker.ViewModel.ViewModels
{
    using StudyTracker.ViewModel.MVVM;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Data context of list of all user exercises.
    /// </summary>
    class BacklogViewModel : ViewModelBase
    {
        /// <summary>
        /// Collection of all exercises.
        /// </summary>
        private ObservableCollection<ExerciseViewModel> _exercises = null;
        public ObservableCollection<ExerciseViewModel> Exercises
        {
            get { return _exercises; }
            set { _exercises = value; }
        }

        /// <summary>
        /// Initialise instance of <see cref="BacklogViewModel"/>.
        /// </summary>
        public BacklogViewModel()
        {
            GetTestValue();
        }

        /// <summary>
        /// TODO: -- DELETE --
        /// </summary>
        private void GetTestValue()
        {
            _exercises = new ObservableCollection<ExerciseViewModel> {
                new ExerciseViewModel { Name="lab1"},
                new ExerciseViewModel
                { 
                    Name="lab2-5",
                    Children = new ObservableCollection<ExerciseViewModel>
                    {
                        new ExerciseViewModel { Name="lab2"},
                        new ExerciseViewModel { Name="lab3"},
                        new ExerciseViewModel { Name="lab4"},
                        new ExerciseViewModel { Name="lab5"}
                    } 
                }
            };
        }
    }
}
