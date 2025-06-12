using StudyTracker.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudyTracker.View.UserControls
{
    /// <summary>
    /// Логика взаимодействия для CalendarItem.xaml
    /// </summary>
    public partial class MyCalendarItem : UserControl
    {
        public MyCalendarItem()
        {
            InitializeComponent();
        }

        private string _day = string.Empty;
        public string Day
        {
            get { return _day; }
            set
            {
                _day = value;
                DayTextBlock.Text = _day;
            }
        }

        private string _month = string.Empty;
        public string Month
        {
            get { return _month; }
            set
            {
                _month = value;
                MonthTextBlock.Text = _month;
            }
        }

        private ObservableCollection<ExerciseViewModel> _exersices = [];
        public ObservableCollection<ExerciseViewModel> Exercises
        {
            get { return _exersices; }
            set
            {
                _exersices = value;
                ExercisesListBox.ItemsSource = _exersices;
            }
        }

    }
}
