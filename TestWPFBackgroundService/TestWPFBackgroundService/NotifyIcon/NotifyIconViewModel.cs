using System;
using System.Windows;
using System.Windows.Input;
using TestWPFBackgroundService.Commands._base;

namespace TestWPFBackgroundService.NotifyIcon
{
    public class NotifyIconViewModel
    {
        /// <summary>
        /// Shows a window, if none is already open.
        /// </summary>
        public ICommand ShowWindowCommand
        {
            get
            {
                return new DelegateCommand
                {
                    CanExecuteFunc = () => Application.Current.MainWindow == null,
                    CommandAction = () =>
                    {
                        Application.Current.MainWindow = new MainWindow();
                        Application.Current.MainWindow.Show();
                    }
                };
            }
        }

        /// <summary>
        /// Hides the main window. This command is only enabled if a window is open.
        /// </summary>
        public ICommand HideWindowCommand
        {
            get
            {
                return new DelegateCommand
                {
                    CommandAction = () => Application.Current.MainWindow.Close(),
                    CanExecuteFunc = () => Application.Current.MainWindow != null
                };
            }
        }

        /// <summary>
        /// Shuts down the application.
        /// </summary>
        public ICommand ExitApplicationCommand => new DelegateCommand { CommandAction = () => Application.Current.Shutdown() };

        public Uri MyIcon => GetAbsoluteUri("/NotifyIcon/Icon.ico");

        private static Uri GetAbsoluteUri(string path)
        {
            return new Uri(path, UriKind.Relative);
        }
    }
}
