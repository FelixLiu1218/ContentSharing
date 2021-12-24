using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NewProject
{
    public class LoginViewModel :BaseViewModel
    {
        #region public Properties

        /// <summary>
        /// the email of user
        /// </summary>
        public string Email { get; set; }

        public bool LoginIsRunning { get; set; }
        /// <summary>
        /// the password of user
        /// </summary>
        public SecureString Password { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// the command to login
        /// </summary>
        public ICommand LoginCommand { get; set; }

        #endregion

        #region Constructor
        public LoginViewModel()
        {
            LoginCommand = new RelayParameterizedCommand(async(parameter) => await Login(parameter));
        }

        #endregion
        /// <summary>
        /// attempts to log the user in
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task Login(object parameter)
        {
            await RunCommand(() => this.LoginIsRunning, async () =>
            {
                await Task.Delay(5000);

                var email = this.Email;
                var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
            }
            );
            
        }
    }
}