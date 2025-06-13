namespace StudyTracker.ViewModel.ViewModels
{
    using StudyTracker.ViewModel.MVVM;
    using System.Windows.Input;

    /// <summary>
    /// View model of CalendarItem.
    /// </summary>
    public class MyCalendarItemViewModel: ViewModelBase
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
        /// Information of that day.
        /// </summary>
        private CalendarDates _dateData;
        public CalendarDates DateData
        {
            get { return _dateData; }
            set
            {
                _dateData = value;
                Month = _monthDictionary[_dateData.Date.Month];
            }
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
        /// <param name="add">Add exercise command.</param>
        /// <param name="edit">Edit exercise command.</param>
        /// <param name="dateData">Information of the day.</param>
        public MyCalendarItemViewModel(ICommand add, ICommand edit, CalendarDates dateData)
        {
            DateData = dateData;
            AddExercise = add;
            EditExercise = edit;
        }

    }
}
