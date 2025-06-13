using StudyTracker.Model;
using StudyTracker.View.UserControls;
using StudyTracker.ViewModel.Commands;
using StudyTracker.ViewModel.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StudyTracker.View
{
    /// <summary>
    /// Логика взаимодействия для Calendar.xaml
    /// </summary>
    public partial class Calendar : UserControl
    {
        public Calendar()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var dc = (CalendarViewModel)this.DataContext;

            for (int i = 0; i < 31; i++)
            {
                var date = DateTime.Now.AddDays(-15 + i);
                CalendarWrapPanel.Children.Add(
                    new MyCalendarItem()
                    {
                        DataContext = new MyCalendarItemViewModel(dc.AddExercise, dc.EditExercise)
                        {
                            Date = DateOnly.FromDateTime(date),
                            Exercises = dc.FindExerciseToDate(date)
                        }
                    });
            }

        }
    }
}
