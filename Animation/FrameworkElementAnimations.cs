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

        /// <summary>
        /// slides an element in from the bottom
        /// </summary>
        /// <param name="page"></param>
        /// <param name="seconds"></param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animation</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromBottom(this FrameworkElement element, float seconds = 0.45f, bool keepMargin = true, int height = 0)
        {
            var sb = new Storyboard();

            //Add slide from bottom animation
            sb.AddSlideFromBottom(seconds, height == 0 ? element.ActualHeight : height, keepMargin: keepMargin);

            //Add slide from bottom animation
            sb.AddFadeIn(seconds);


            //Start animating
            sb.Begin(element);

            //make page visible
            element.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// slides an element out to the bottom
        /// </summary>
        /// <param name="page"></param>
        /// <param name="seconds"></param>
        /// <param name="keepMargin">Whether to keep the element at the same height during animation</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToBottom(this FrameworkElement element, float seconds = 0.45f, bool keepMargin = true, int height = 0)
        {
            var sb = new Storyboard();

            //Add slide to bottom animation
            sb.AddSlideToBottom(seconds, height == 0 ? element.ActualHeight : height, keepMargin: keepMargin);

            //Add slide to bottom animation
            sb.AddFadeOut(seconds);


            //Start animating
            sb.Begin(element);

            //make page visible
            element.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Fade in
        /// </summary>
        /// <param name="page"></param>
        /// <param name="seconds"></param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animation</param>
        /// <returns></returns>
        public static async Task FadeIn(this FrameworkElement element, float seconds = 0.45f)
        {
            var sb = new Storyboard();

            //Add slide from bottom animation
            sb.AddFadeIn(seconds);


            //Start animating
            sb.Begin(element);

            //make page visible
            element.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Fade out
        /// </summary>
        /// <param name="page"></param>
        /// <param name="seconds"></param>
        /// <param name="keepMargin">Whether to keep the element at the same height during animation</param>
        /// <returns></returns>
        public static async Task FadeOut(this FrameworkElement element, float seconds = 0.45f)
        {
            var sb = new Storyboard();

            //Add slide to bottom animation
            sb.AddFadeOut(seconds);


            //Start animating
            sb.Begin(element);

            //make page visible
            element.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));

            element.Visibility = Visibility.Collapsed;
        }
    }
}
