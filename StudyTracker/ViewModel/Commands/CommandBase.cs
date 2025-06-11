namespace StudyTracker.ViewModel.Commands
{
    using System.ComponentModel;
    using System.Windows.Input;

    /// <summary>
    /// Base class to create commands.
    /// </summary>
    public abstract class CommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// Check ability to execute command.
        /// </summary>
        /// <param name="parameter">Command parameter.</param>
        /// <returns>True - command can be executed.</returns>
        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }

        /// <summary>
        /// Command action.
        /// </summary>
        /// <param name="parameter">Command parameter.</param>
        public abstract void Execute(object? parameter);

        protected void OnCanExecutedChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
