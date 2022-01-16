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
    /// ChatPage.xaml 的互動邏輯
    /// </summary>
    public partial class ChatPage : BasePage<ChatMessageListViewModel>
    {
        public ChatPage()
        {
            InitializeComponent();
        }
    }
}
