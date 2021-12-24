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
    /// ChatPage.xaml 的互動邏輯
    /// </summary>
    public partial class ChatPage : BasePage<LoginViewModel>
    {
        public ChatPage()
        {
            InitializeComponent();
        }
    }
}
