namespace StudyTracker
{
    using StudyTracker.Stores;
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
            _navigationStore.CurrentViewModel = new CalendarViewModel();
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
                new ExerciseViewModel { Name="lab1"},
                new ExerciseViewModel
                {
                    Name="lab2-5",
                    Children = new ObservableCollection<ExerciseViewModel>
                    {
                        new ExerciseViewModel { Name="lab2"},
                        new ExerciseViewModel { Name="lab3"},
                        new ExerciseViewModel { Name="lab4"},
                        new ExerciseViewModel { Name="lab5"}
                    }
                }
            };
        }
    }
}
