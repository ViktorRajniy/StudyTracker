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

        private DateTime _creationTime = DateTime.Now;
        public DateTime CreationTime
        {
            get { return _creationTime; }
        }

        private DateTime _deadline = DateTime.Now;
        public DateTime Deadline
        {
            get { return _deadline; }
            set { _deadline = value; }
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

        public ExerciseViewModel(
                                string title,
                                DateTime deadline,
                                string description = null,
                                ExerciseViewModel? parent = null,
                                ObservableCollection<ExerciseViewModel>? exercises = null)
        {
            _creationTime = DateTime.Now;
            Deadline = deadline;
            Title = title;
            Description = description;
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

        public string GetBacklogDeadline()
        {
            return "Deadline: " + DateOnly.FromDateTime(Deadline);
        }
    }
}
