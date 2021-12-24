using System;
using System.Configuration;
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

    private VM mViewModel;

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
        get { return mViewModel; }
        set
        {
            if (mViewModel == value) return;

            mViewModel = value;

            //set the data context for this page
            this.DataContext = mViewModel;
        }
    }

    #endregion

    #region Constructor

    public BasePage()
    {
        if (this.PageLoadAnimation != PageAnimation.None)
        {
            this.Visibility = Visibility.Collapsed;
        }


        this.Loaded += BasePage_Loaded;
        
        //default view model
        this.ViewModel = new VM();
    }

    #endregion

    #region Animation Load or Unload

    private async void BasePage_Loaded(object sender, RoutedEventArgs e)
    {
        await AnimateIn();
    }

    public async Task AnimateIn()
    {
        if (this.PageLoadAnimation == PageAnimation.None) return;

        switch (this.PageLoadAnimation)
        {
            case PageAnimation.SlideAndFadeInFromRight:

                //Start the animation
                await this.SlideAndFadeInFromRight(this.SlideSeconds * 2);

                break;
        }
    }

    public async Task AnimateOut()
    {
        if (this.PageUnloadAnimation == PageAnimation.None) return;

        switch (this.PageUnloadAnimation)
        {
            case PageAnimation.SlideAndFadeOutToLeft:

                //Start the animation
                await this.SlideAndFadeOutToLeft(this.SlideSeconds * 2);

                break;
        }
    }

    #endregion




    }
}
