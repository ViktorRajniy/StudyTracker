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
    class MyCalendarItemViewModel: ViewModelBase
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

        private DateOnly _date;
        public DateOnly Date
        {
            get { return _date; }
            set
            {
                _date = value;
                Month = _monthDictionary[_date.Month];
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

        private ObservableCollection<ExerciseViewModel> _exersices = [];
        public ObservableCollection<ExerciseViewModel> Exercises
        {
            get { return _exersices; }
            set
            {
                _exersices = value;
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

        public MyCalendarItemViewModel(ICommand add, ICommand edit)
        {
            AddExercise = add;
            EditExercise = edit;
        }

    }
}
