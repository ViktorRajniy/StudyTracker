namespace StudyTracker
{
    using StudyTracker.Stores;
    using StudyTracker.ViewModel.MVVM;
    using StudyTracker.ViewModel.ViewModels;
    using System.Collections.ObjectModel;
    using System.Windows;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Navigation store.
        /// </summary>
        private readonly NavigationStore _navigationStore;

        /// <summary>
        /// Data of user exercises.
        /// </summary>
        private ObservableCollection<ExerciseViewModel> _exercises = new ObservableCollection<ExerciseViewModel>();

        /// <summary>
        /// Initialise instance of application.
        /// </summary>
        public App()
        {
            _navigationStore = new NavigationStore();
        }

        /// <summary>
        /// Action on start of application.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            GetTestValue();
            _navigationStore.CurrentViewModel = new CalendarViewModel(_exercises);
            var MainWindow = new MainViewModel(_navigationStore, _exercises);
            MainWindow.View.Show();

            base.OnStartup(e);
        }

        /// <summary>
        /// TODO: -- DELETE --
        /// </summary>
        private void GetTestValue()
        {
            _exercises = new ObservableCollection<ExerciseViewModel> {
                new ExerciseViewModel("Mobile development", DateTime.Now.AddDays(-5)),
                new ExerciseViewModel
                (
                    "Mobile development - Kurs", DateTime.Now.AddDays(-4)
                )
            };
            _exercises[_exercises.Count - 1].AddChild(new ExerciseViewModel("Technical specification", DateTime.Now.AddDays(-3), "Make tech. speecification"));
            _exercises[_exercises.Count - 1].AddChild(new ExerciseViewModel("First step", DateTime.Now.AddDays(-2), "Fitst step of development"));
            _exercises[_exercises.Count - 1].AddChild(new ExerciseViewModel("Second step", DateTime.Now.AddDays(-1), "Second step of development"));
            _exercises[_exercises.Count - 1].AddChild(new ExerciseViewModel("Preserntation", DateTime.Now, "ujbafujbafujbafujbafujbafujbafujbafujbafujbafujbaf"));
    }
}
}
