using StudyTracker.View.UserControls;
using StudyTracker.ViewModel.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace StudyTracker.View
{
    /// <summary>
    /// Логика взаимодействия для Calendar.xaml
    /// </summary>
    public partial class Calendar : UserControl
    {
        private readonly Dictionary<int, string> _monthDictionary = new Dictionary<int, string>()
        {
            {1, "January"  },
            {2, "February"  },
            {3, "March"  },
            {4, "April"  },
            {5, "May"  },
            {6, "June"  },
            {7, "July"  },
            {8, "August"  },
            {9, "September"  },
            {10, "October"  },
            {11, "November"  },
            {12, "December"  },
        };

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
                        Day = date.Day.ToString(),
                        Month = _monthDictionary[date.Month],
                        Exercises = dc.FindExerciseToDate(date)
                    });
            }

        }
    }
}
