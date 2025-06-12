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
        private int _key;
        public int Key { get; }

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
                                string description = null,
                                ExerciseViewModel parent = null,
                                ObservableCollection<ExerciseViewModel> exercises = null)
        {
            _key = title.GetHashCode();
            Title = title;
            Description = description;
            Parent = parent;
            if (exercises == null)
            {
                Children = new ObservableCollection<ExerciseViewModel>();
            }
            else
            {
                Children = exercises;
            }
        }

        public void Copy(ExerciseViewModel newExercise)
        {
            Title = newExercise.Title;
            Description = newExercise.Description;
            OnPropertyChanged(nameof(ExerciseViewModel));
        }
    }
}
