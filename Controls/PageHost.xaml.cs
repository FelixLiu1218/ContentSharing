using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NewProject.Core;

namespace NewProject
{
    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {
        #region Constructor

        public PageHost()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this))
            {
                NewPage.Content =
                    (BasePage) new ApplicationPageValueConverter().Convert(IoC.Get<ApplicationViewModel>().CurrentPage);
            }
        }

        #endregion


        #region Dependency Properties

        /// <summary>
        /// the current page to show in the page host
        /// </summary>
        public BasePage CurrentPage
        {
            get => (BasePage)GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value);
        }

        /// <summary>
        /// registers  CURRENT PAGE as a dependency property
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(BasePage), typeof(PageHost), new UIPropertyMetadata(CurrentPagePropertyChanged));


        #endregion


        #region Propert Changed Events

        private static void CurrentPagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //get the frames
            var newPageFrame = (d as PageHost).NewPage;
            var oldPageFrame = (d as PageHost).OldPage;

            //store the current page content as the old page
            var oldPageContent = newPageFrame.Content;

            //remove current page from new page frame
            newPageFrame.Content = null;

            //move the previous page into the ole page frame
            oldPageFrame.Content = oldPageContent;

            //Animate out previous page
            if (oldPageContent is BasePage oldPage)
            {
                //tell old page animate out
                oldPage.ShouldAnimateOut = true;

                //remove old page
                Task.Delay((int) (oldPage.SlideSeconds * 1000)).ContinueWith((t) =>
                {
                    Application.Current.Dispatcher.Invoke(() => oldPageFrame.Content = null);
                });
            }
            
            //set the new page content
            newPageFrame.Content = e.NewValue;

            #endregion
        }
    }
}
