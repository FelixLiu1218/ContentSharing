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
                };

                //hook into the loaded event of the element
                element.Loaded += onLoaded;
            }
        }

        protected virtual void DoAnimation(FrameworkElement element, bool value)
        {
            
        }
    }
}
