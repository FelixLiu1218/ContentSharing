using NewProject.Core;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace NewProject
{
    public class BasePage<VM> : Page
        where VM:BaseViewModel,new()

    {

    #region Private menber

    private VM _viewModel;

    #endregion


    #region Public Properties

    public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

    public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

    public float SlideSeconds { get; set; } = 0.8f;

    /// <summary>
    /// the view model associated with this page
    /// </summary>
    public VM ViewModel
    {
        get => _viewModel; 
        set
        {
            if (_viewModel == value) return;

            _viewModel = value;

            //set the data context for this page
            DataContext = _viewModel;
        }
    }

    #endregion

    #region Constructor

    public BasePage()
    {

        if (PageLoadAnimation != PageAnimation.None)
        {
            Visibility = Visibility.Collapsed;
        }


        Loaded += BasePage_Loaded;
        
        //default view model
        ViewModel = new VM();
    }

        #endregion

        #region Animation Load or Unload


        public async Task AnimateIn()
        {
            if (PageLoadAnimation == PageAnimation.None) return;

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:

                    //Start the animation
                    this.SlideAndFadeInFromRight(SlideSeconds);

                    break;
                default:
                    Debugger.Break();
                    break;
            }
        }
        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
    {
        await AnimateIn();
    }

    

    public async Task AnimateOut()
    {
        if (PageUnloadAnimation == PageAnimation.None) return;

        switch (PageUnloadAnimation)
        {
            case PageAnimation.SlideAndFadeOutToLeft:

                //Start the animation
                await this.SlideAndFadeOutToLeft(SlideSeconds);

                break;
        }
    }

    #endregion




    }
}
