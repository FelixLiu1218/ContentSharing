using System.Windows.Controls;
using System;
using System.Data;
using System.Windows;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Security;
using NewProject.Core;

namespace NewProject
{
    /// <summary>
    /// RegisterPage.xaml 的互動邏輯
    /// </summary>
    public partial class RegisterPage : BasePage<LoginViewModel>,IHavePassword
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        //the secure password for this login page
        public SecureString SecurePassword  => PasswordText.SecurePassword;
    }
}
