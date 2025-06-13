using StudyTracker.ViewModel.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudyTracker.ViewModel.ViewModels
{
    public class MyCalendarItemViewModel: ViewModelBase
    {
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

        public MyCalendarItemViewModel(ICommand add, ICommand edit, CalendarDates dateData)
        {
            DateData = dateData;
            AddExercise = add;
            EditExercise = edit;
        }

    }
}
