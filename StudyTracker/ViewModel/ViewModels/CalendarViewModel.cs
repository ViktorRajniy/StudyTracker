namespace StudyTracker.ViewModel.ViewModels
{
    using StudyTracker.ViewModel.Commands;
    using StudyTracker.ViewModel.MVVM;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;

    public class CalendarViewModel : ViewModelBase
    {
        /// <summary>
        /// Collection of all exercises.
        /// </summary>
        private ObservableCollection<ExerciseViewModel> _exercises = new();
        public ObservableCollection<ExerciseViewModel> Exercises
        {
            get { return _exercises; }
            set
            {
                _exercises = value;
                UpdateExerciseList();
            }
        }

        /// <summary>
        /// Command to add exercise.
        /// </summary>
        public ICommand AddExercise { get; }

        /// <summary>
        /// Command to edit exercise.
        /// </summary>
        public ICommand EditExercise { get; }

        private List<ExerciseViewModel> _exerciseList = [];

        /// <summary>
        /// Initialise instance of <see cref="CalendarViewModel"/>.
        /// </summary>
        public CalendarViewModel(ObservableCollection<ExerciseViewModel> exercises)
        {
            Exercises = exercises;
            AddExercise = new AddExerciseCommand(exercises);
            EditExercise = new EditExerciseCommand(exercises);
        }

        public ObservableCollection<ExerciseViewModel> FindExerciseToDate(DateTime time)
        {
            var finded = _exerciseList.FindAll(e => DateOnly.FromDateTime(e.Deadline) == DateOnly.FromDateTime(time));
            var result = new ObservableCollection<ExerciseViewModel>();
            foreach (var k in finded)
            {
                result.Add(k);
            }
            return result;
        }

        private void UpdateExerciseList()
        {
            foreach (var exercise in Exercises)
            {
                if (exercise.Children.Count != 0)
                {
                    _exerciseList.AddRange(GetExerciseChildren(exercise));
                }
                else
                {
                    _exerciseList.Add(exercise);
                }
            }
        }

        private List<ExerciseViewModel> GetExerciseChildren(ExerciseViewModel exercise)
        {
            List<ExerciseViewModel> list = [];
            if (exercise.Children.Count != 0)
            {
                foreach (var exer in exercise.Children)
                {
                    list.AddRange(GetExerciseChildren(exer));
                }
            }
            list.Add(exercise);
            return list;
        }
    }
}
