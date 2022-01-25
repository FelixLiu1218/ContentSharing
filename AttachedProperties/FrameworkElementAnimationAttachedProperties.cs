using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Media.Animation;

namespace NewProject
{
    /// <summary>
    /// A base class to run any animation method when a boolean is set to true
    /// and a reverse animation when set to false
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public abstract class AnimateBaseProperty<Parent> : BaseAttachedProperty<Parent, bool>
    where Parent : BaseAttachedProperty<Parent,bool>,new()
    {
        #region Public Properties

        public bool FirstLoad { get; set; } = true;

        #endregion

        
        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            //get the framework element
            if (!(sender is FrameworkElement element)) return;

            //Don't fire if the value doesn't change
            if (sender.GetValue(ValueProperty) == value && !FirstLoad) return;

            //On first load
            if (FirstLoad)
            {
                //create a single self-unhookable event
                //for the elements loaded event
                RoutedEventHandler onLoaded = null;
                onLoaded = (ss, ee) =>
                {
                    //unhook ourselves
                    element.Loaded -= onLoaded;

                    //do desired animation
                    DoAnimation(element, (bool) value);

                    //no longer in first load
                    FirstLoad = false;
                };

                //hook into the loaded event of the element
                element.Loaded += onLoaded;
            }
            else
            {
                //do desired animation
                DoAnimation(element,(bool)value);
            }
        }

        protected virtual void DoAnimation(FrameworkElement element, bool value)
        {
            
        }
    }

    /// <summary>
    /// animates a framework element sliding it in from the left on show
    /// and sliding out to the left on hide
    /// </summary>
    public class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
            {
                //Animate in
                await element.SlideAndFadeInFromLeft(FirstLoad ? 0 : 0.45f,keepMargin:false);
            }
            else
            {
                //Animate Out
                await element.SlideAndFadeOutToLeft(FirstLoad ? 0 : 0.45f,keepMargin:false);
            }
        }
    }

    /// <summary>
    /// animates a framework element sliding up from bottom on show
    /// and sliding out to the bottom on hide
    /// </summary>
    public class AnimateSlideInFromBottomProperty : AnimateBaseProperty<AnimateSlideInFromBottomProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
            {
                //Animate in
                await element.SlideAndFadeInFromBottom(FirstLoad ? 0 : 0.45f, keepMargin: false);
            }
            else
            {
                //Animate Out
                await element.SlideAndFadeOutToBottom(FirstLoad ? 0 : 0.45f, keepMargin: false);
            }
        }
    }

    /// <summary>
    /// animates a framework element fading in 
    /// and fading out on hide
    /// </summary>
    public class AnimateFadeInProperty : AnimateBaseProperty<AnimateFadeInProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
            {
                //Animate in
                await element.FadeIn(FirstLoad ? 0 : 0.45f);
            }
            else
            {
                //Animate Out
                await element.FadeOut(FirstLoad ? 0 : 0.45f);
            }
        }
    }
}
