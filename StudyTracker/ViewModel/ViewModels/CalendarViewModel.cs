namespace StudyTracker.ViewModel.ViewModels
{
    using StudyTracker.ViewModel.Commands;
    using StudyTracker.ViewModel.MVVM;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    /// <summary>
    /// View model of calendar.
    /// </summary>
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
                UpdateDaysViewModels();
            }
        }

        /// <summary>
        /// List of exercises. List from tree-structure.
        /// </summary>
        private List<ExerciseViewModel> _exerciseList = [];
        public List<ExerciseViewModel> ExerciseList
        {
            get { return _exerciseList; }
            set
            {
                _exerciseList = value;
            }
        }

        /// <summary>
        /// Collection of viewModels of calendar day element.
        /// </summary>
        private ObservableCollection<MyCalendarItemViewModel> _daysViewModels = [];
        public ObservableCollection<MyCalendarItemViewModel> DaysViewModels
        {
            get { return _daysViewModels; }
            set
            {
                _daysViewModels = value;
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

        /// <summary>
        /// Initialise instance of <see cref="CalendarViewModel"/>.
        /// </summary>
        public CalendarViewModel(ObservableCollection<ExerciseViewModel> exercises)
        {
            AddExercise = new AddExerciseCommand(exercises);
            EditExercise = new EditExerciseCommand(exercises);
            Exercises = exercises;
        }

        /// <summary>
        /// Find all exercises where deadline date match date of the day.
        /// </summary>
        /// <param name="date">Date where we want to find deadlines.</param>
        /// <returns>Collection of exercises where deadline date is today.</returns>
        public ObservableCollection<ExerciseViewModel> FindExerciseToDate(DateOnly date)
        {
            var finded = _exerciseList.FindAll(e => DateOnly.FromDateTime(e.Deadline) == date);
            var result = new ObservableCollection<ExerciseViewModel>();
            foreach (var findedExercise in finded)
            {
                result.Add(findedExercise);
            }
            return result;
        }

        /// <summary>
        /// Update collection of days in calendar.
        /// </summary>
        private void UpdateDaysViewModels()
        {
            for (int i = 0; i < 31; i++)
            {
                var newDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-15 + i));
                DaysViewModels.Add(new MyCalendarItemViewModel(AddExercise, EditExercise,
                                                               new CalendarDates(newDate)));
                DaysViewModels.Last().DateData.ExerciseList = FindExerciseToDate(newDate).ToList();
            }
        }

        /// <summary>
        /// Update list of exercises from tree-structure,
        /// </summary>
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

        /// <summary>
        /// Get list of exercise sub-exercises.
        /// </summary>
        /// <param name="exercise">Exercise-father</param>
        /// <returns>List of exercises.</returns>
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
