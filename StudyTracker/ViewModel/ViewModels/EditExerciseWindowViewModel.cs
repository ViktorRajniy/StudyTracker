using StudyTracker.View;
using StudyTracker.ViewModel.MVVM;

namespace StudyTracker.ViewModel.ViewModels
{
    public class EditExerciseWindowViewModel : BaseWindowViewModel<EditExerciseWindow>
    {
        /// <summary>
        /// Data of exercise that creating.
        /// </summary>
        private ExerciseViewModel _exercise;
        public ExerciseViewModel Exercise
        {
            get { return _exercise; }
            set { _exercise = value; OnPropertyChanged(nameof(Exercise)); }
        }

        public EditExerciseWindowViewModel(ExerciseViewModel exercise)
        {
            Exercise = exercise;
        }
    }
}
