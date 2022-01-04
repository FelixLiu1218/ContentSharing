using NewProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NewProject
{
    public class WindowViewModel :BaseViewModel
    {
        #region Private member

        private Window _window;

        #endregion

        #region public Properties

        

        #endregion

        #region Constructor
        public WindowViewModel(Window window)
        {
            _window = window;
        }
        #endregion

    }
}