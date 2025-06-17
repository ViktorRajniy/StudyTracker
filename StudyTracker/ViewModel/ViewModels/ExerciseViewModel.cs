namespace StudyTracker.ViewModel.ViewModels
{
    using StudyTracker.Model;
    using StudyTracker.ViewModel.MVVM;
    using System.Collections.ObjectModel;

    /// <summary>
    /// View model of exercise.
    /// </summary>
    public class ExerciseViewModel : ViewModelBase
    {
        /// <summary>
        /// Name of exercise.
        /// </summary>
        private string _title = string.Empty;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// Description of the exercise.
        /// </summary>
        private string _description = string.Empty;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// Time of creation.
        /// </summary>
        private DateTime _creationTime = DateTime.Now;
        public DateTime CreationTime
        {
            get { return _creationTime; }
        }

        /// <summary>
        /// Date when exercise have to be done.
        /// </summary>
        private DateTime _deadline = DateTime.Now;
        public DateTime Deadline
        {
            get { return _deadline; }
            set { _deadline = value; }
        }

        /// <summary>
        /// Flag that show exercise is group of exercises or exercise.
        /// True - exercise will be shown in calendar.
        /// False - exercise will be not shown in calendar.
        /// </summary>
        private bool _isExercise = true;
        public bool IsExercise
        {
            get { return _isExercise; }
            set { _isExercise = value; }
        }

        /// <summary>
        /// Main exercise. Also parent of that node in tree.
        /// </summary>
        private ExerciseViewModel? _parent = null;
        public ExerciseViewModel Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        /// <summary>
        /// Subexercises. Children of that node in tree.
        /// </summary>
        private ObservableCollection<ExerciseViewModel>? _children = null;
        public ObservableCollection<ExerciseViewModel> Children
        {
            get { return _children; }
            set { _children = value; }
        }

        /// <summary>
        /// Initialise instancec of class.
        /// </summary>
        /// <param name="title">Title of exercise.</param>
        /// <param name="deadline">Deadline date.</param>
        /// <param name="description">Description of exercise.</param>
        /// <param name="parent">Parent of exercise.</param>
        /// <param name="exercises">Sub-exercises of exercise.</param>
        public ExerciseViewModel(
                                string title,
                                DateTime deadline,
                                string description = null,
                                bool isExercise = true,
                                ExerciseViewModel? parent = null,
                                ObservableCollection<ExerciseViewModel>? exercises = null)
        {
            _creationTime = DateTime.Now;
            Deadline = deadline;
            Title = title;
            Description = description;
            IsExercise = isExercise;
            Parent = parent;
            if (exercises == null)
            {
                Children = [];
            }
            else
            {
                Children = exercises;
            }
        }

        /// <summary>
        /// Add sub-exercise.
        /// </summary>
        /// <param name="newChild">Sub-exercise.</param>
        public void AddChild(ExerciseViewModel newChild)
        {
            Children.Add(newChild);
            Children.Last().Parent = this;
        }
    }
}
