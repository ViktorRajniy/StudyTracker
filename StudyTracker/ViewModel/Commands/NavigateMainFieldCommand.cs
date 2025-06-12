namespace StudyTracker.ViewModel.Commands
{
    using StudyTracker.Stores;
    using StudyTracker.ViewModel.Enums;
    using StudyTracker.ViewModel.ViewModels;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Command that change main field of window.
    /// </summary>
    public class NavigateMainFieldCommand : CommandBase
    {
        /// <summary>
        /// Store of navigation.
        /// </summary>
        private readonly NavigationStore _navigationStore;

        private ObservableCollection<ExerciseViewModel> _exercises = new ObservableCollection<ExerciseViewModel>();

        /// <summary>
        /// Initiate the instance of <see cref="NavigateMainFieldCommand"/>.
        /// </summary>
        /// <param name="navigationStore">Store of navigation.</param>
        public NavigateMainFieldCommand(NavigationStore navigationStore, ObservableCollection<ExerciseViewModel> exercises)
        {
            _navigationStore = navigationStore;
            _exercises = exercises;
        }

        /// <summary>
        /// Change the main field of window.
        /// </summary>
        /// <param name="parameter">Type of main field. Have to be <see cref="MainFieldType"/></param>
        public override void Execute(object? parameter)
        {
            if(parameter.GetType() == typeof(MainFieldType))
            {
                switch (parameter)
                {
                    case MainFieldType.Calendar:
                        {
                            _navigationStore.CurrentViewModel = new CalendarViewModel(_exercises);
                            break;
                        }
                    case MainFieldType.GantDiagram:
                        {
                            _navigationStore.CurrentViewModel = new GantDiagrammViewModel();
                            break;
                        }
                    case MainFieldType.Backlog:
                        {
                            _navigationStore.CurrentViewModel = new BacklogViewModel(_exercises);
                            break;
                        }
                }
            }
        }
    }
}
