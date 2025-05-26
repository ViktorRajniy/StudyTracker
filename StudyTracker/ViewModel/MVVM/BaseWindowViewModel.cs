namespace StudyTracker.ViewModel.MVVM
{
    using System.Windows;
    using System.Windows.Input;

    class BaseWindowViewModel<T>: ViewModelBase
        where T : Window, new()
    {
        private Window _view;

        protected BaseWindowViewModel()
        {
            View = new T
            {
                DataContext = this
            };
        }

        public Window View
        {
            get => _view;
            set
            {
                if (_view != value)
                {
                    _view = value;
                    OnPropertyChanged(nameof(View));
                }
            }
        }

        private bool Result { get; set; }

        public bool ShowDialog()
        {
            View.ShowDialog();
            return Result;
        }

        private void SetResultAndClose(MessageBoxResult result)
        {
            View.DialogResult = result == MessageBoxResult.OK || result == MessageBoxResult.Yes;
            View.Close();
        }

        public RelayCommand ApplyCommand => new RelayCommand(_ => Apply(), CanApply);

        protected virtual bool CanApply(object o)
        {
            return true;
        }

        protected virtual void Apply()
        {
            SuccessClose();
        }

        public ICommand CancelCommand => new RelayCommand(Cancel, CanCancel);

        protected virtual bool CanCancel(object o)
        {
            return true;
        }

        protected virtual void Cancel(object o)
        {
            CancelClose();
        }

        protected void SuccessClose()
        {
            SetResultAndClose(MessageBoxResult.OK);
        }

        protected void CancelClose()
        {
            SetResultAndClose(MessageBoxResult.Cancel);
        }
    }
}
