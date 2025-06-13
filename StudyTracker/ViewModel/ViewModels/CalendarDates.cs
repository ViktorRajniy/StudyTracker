namespace StudyTracker.ViewModel.ViewModels
{
    using StudyTracker.ViewModel.MVVM;

    /// <summary>
    /// View model of calendar day element.
    /// </summary>
    public class CalendarDates : ViewModelBase
    {
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
        /// Initialise instance of class.
        /// </summary>
        /// <param name="date"></param>
        public CalendarDates(DateOnly date)
        {
            Date = date;
        }
    }
}
