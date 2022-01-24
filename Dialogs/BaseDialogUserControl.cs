using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using NewProject.Core;

namespace NewProject
{
    /// <summary>
    /// The base class for any content that is being used inside of a <see cref="DialogWindow"/>
    /// </summary>
    public class BaseDialogUserControl :UserControl
    {
        #region Private Members

        private DialogWindow _dialogWindow;


        #endregion

        #region Public Properties

        /// <summary>
        /// The minimum width of the dialog
        /// </summary>
        public int WindowMinimumWidth { get; set; } = 250;

        /// <summary>
        /// The minimum height of the dialog
        /// </summary>
        public int WindowMinimumHeight { get; set; } = 100;

        /// <summary>
        /// The title for the dialog
        /// </summary>
        public string Title { get; set; }

        #endregion


        #region Public Commands




        #endregion

        #region Constructor

        public BaseDialogUserControl()
        {
            _dialogWindow = new DialogWindow();
            _dialogWindow.ViewModel = new DialogWindowViewModel(_dialogWindow);
        }

        #endregion

        #region Dialog Methods

        /// <summary>
        /// Display a single message box to the user
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public Task ShowDialog(MessageBoxDialogViewModel viewModel)
        {
            //create a task to await the dialog closing
            var tcs = new TaskCompletionSource<bool>();

            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    _dialogWindow.ViewModel.Title = Title;


                    //show dialog
                    _dialogWindow.ShowDialog();
                }
                finally
                {
                    //let caller know me finished
                    tcs.TrySetResult(true);
                }

            });

            return tcs.Task;
        }

        #endregion
    }
}
