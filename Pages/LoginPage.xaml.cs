using System.Windows.Controls;
using System;
using System.Data;
using System.Windows;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Security;

namespace NewProject
{
    /// <summary>
    /// LoginPage.xaml 的互動邏輯
    /// </summary>
    public partial class LoginPage : BasePage<LoginViewModel>,IHavePassword
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        //the secure password for this login page
        public SecureString SecurePassword  => PasswordText.SecurePassword;
    }
}
