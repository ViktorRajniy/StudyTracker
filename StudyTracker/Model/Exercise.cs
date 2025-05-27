namespace StudyTracker.Model
{
    /// <summary>
    /// Exercise that user want to do.
    /// </summary>
    public class Exercise
    {
        /// <summary>
        /// Name of exercise.
        /// </summary>
        private string _name = string.Empty;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
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
    }
}
