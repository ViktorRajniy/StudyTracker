namespace StudyTracker.ViewModel.ViewModels
{
    using StudyTracker.ViewModel.MVVM;
    using System.Windows.Input;

    /// <summary>
    /// View model of calendar day element.
    /// </summary>
    public class CalendarDates : ViewModelBase
    {
        /// <summary>
        /// Dictionary of month names.
        /// </summary>
        private readonly Dictionary<int, string> _monthDictionary = new Dictionary<int, string>()
        {
            {1, "January"  },
            {2, "February"  },
            {3, "March"  },
            {4, "April"  },
            {5, "May"  },
            {6, "June"  },
            {7, "July"  },
            {8, "August"  },
            {9, "September"  },
            {10, "October"  },
            {11, "November"  },
            {12, "December"  },
        };

        /// <summary>
        /// Date of the day.
        /// </summary>
        private DateOnly _date;
        public DateOnly Date
        {
            get { return _date; }
            set { _date = value; }
        }

        /// <summary>
        /// Month name string.
        /// </summary>
        private string _month;
        public string Month
        {
            get { return _month; }
            set
            {
                _month = value;
            }
        }

        /// <summary>
        /// List of exercises have to be done to this date.
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
        /// Command to add exercise.
        /// </summary>
        public ICommand AddExercise { get; }

        /// <summary>
        /// Command to edit exercise.
        /// </summary>
        public ICommand EditExercise { get; }

        /// <summary>
        /// Initialise instance of class.
        /// </summary>
        /// <param name="date"></param>
        public CalendarDates(DateOnly date, ICommand add, ICommand edit)
        {
            Date = date;
            Month = _monthDictionary[Date.Month];
            AddExercise = add;
            EditExercise = edit;
        }
    }
}
