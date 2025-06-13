namespace StudyTracker.ViewModel.ViewModels
{
    using StudyTracker.ViewModel.Commands;
    using StudyTracker.ViewModel.MVVM;
    using System.Collections.Generic;
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
                UpdateDaysViewModels();
            }
        }

        private List<ExerciseViewModel> _exerciseList = [];
        public List<ExerciseViewModel> ExerciseList
        {
            get { return _exerciseList; }
            set
            {
                _exerciseList = value;
            }
        }

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

        public ObservableCollection<ExerciseViewModel> FindExerciseToDate(DateOnly time)
        {
            var finded = _exerciseList.FindAll(e => DateOnly.FromDateTime(e.Deadline) == time);
            var result = new ObservableCollection<ExerciseViewModel>();
            foreach (var k in finded)
            {
                result.Add(k);
            }
            return result;
        }

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
