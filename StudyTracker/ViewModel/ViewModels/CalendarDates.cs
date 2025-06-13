using StudyTracker.ViewModel.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTracker.ViewModel.ViewModels
{
    public class CalendarDates: ViewModelBase
    {
		private DateOnly _date;

		public DateOnly Date
		{
			get { return _date; }
			set { _date = value; }
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

        public CalendarDates(DateOnly date)
        {
            Date = date;
        }
    }
}
