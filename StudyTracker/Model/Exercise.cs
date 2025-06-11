namespace StudyTracker.Model
{
    /// <summary>
    /// Exercise that user want to do.
    /// </summary>
    public class Exercise
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
        private Exercise? _parent = null;
        public Exercise Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        /// <summary>
        /// Subexercises. Children of that node in tree.
        /// </summary>
        private List<Exercise>? _children = null;
        public List<Exercise> Children
        {
            get { return _children; }
            set { _children = value; }
        }

        public Exercise(string title, string description = null, Exercise parent = null, List<Exercise> exercises = null)
        {
            _key = title.GetHashCode();
            Title = title;
            Description = description;
            Parent = parent;
            Children = exercises;
        }

        public void Copy(Exercise newExercise)
        {
            Title = newExercise.Title;
            Description = newExercise.Description;
            Parent = newExercise.Parent;
            Children = newExercise.Children;
        }
    }
}
