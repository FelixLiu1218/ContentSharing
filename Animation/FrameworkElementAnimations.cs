using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace NewProject
{
    public static class FrameworkElementAnimations
    {
        /// <summary>
        /// slides an element in from the right
        /// </summary>
        /// <param name="page"></param>
        /// <param name="seconds"></param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animation</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRight(this FrameworkElement element, float seconds = 0.45f, bool keepMargin = true,int width = 0)
        {
            var sb = new Storyboard();

            //Add slide from right animation
            sb.AddSlideFromRight(seconds,width ==0 ? element.ActualWidth : width,keepMargin : keepMargin);

            //Add slide from right animation
            sb.AddFadeIn(seconds);


            //Start animating
            sb.Begin(element);

            //make page visible
            element.Visibility = Visibility.Visible;

            await Task.Delay((int) (seconds * 1000));
        }


        /// <summary>
        /// slides an element in to the left
        /// </summary>
        /// <param name="page"></param>
        /// <param name="seconds"></param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animation</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromLeft(this FrameworkElement element, float seconds = 0.45f,bool keepMargin = true, int width = 0)
        {
            var sb = new Storyboard();

            //Add slide from right animation
            sb.AddSlideFromLeft(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);

            //Add slide from right animation
            sb.AddFadeIn(seconds);


            //Start animating
            sb.Begin(element);

            //make page visible
            element.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// slides an element out to the left
        /// </summary>
        /// <param name="page"></param>
        /// <param name="seconds"></param>
        /// /// <param name="keepMargin">Whether to keep the element at the same width during animation</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(this FrameworkElement element, float seconds = 0.45f, bool keepMargin = true, int width = 0)
        {
            var sb = new Storyboard();

            //Add slide from right animation
            sb.AddSlideToLeft(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);

            //Add slide from right animation
            sb.AddFadeOut(seconds);


            //Start animating
            sb.Begin(element);

            //make page visible
            element.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// slides an element out to the Right
        /// </summary>
        /// <param name="page"></param>
        /// <param name="seconds"></param>
        /// /// <param name="keepMargin">Whether to keep the element at the same width during animation</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToRight(this FrameworkElement element, float seconds = 0.45f, bool keepMargin = true, int width = 0)
        {
            var sb = new Storyboard();

            //Add slide from right animation
            sb.AddSlideToRight(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);

            //Add slide from right animation
            sb.AddFadeOut(seconds);


            //Start animating
            sb.Begin(element);

            //make page visible
            element.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }
    }
}
