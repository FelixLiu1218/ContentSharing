using System;
using System.Windows;
using System.Windows.Controls;

namespace NewProject
{
    public class MonitorTextProperty : BaseAttachedProperty<MonitorTextProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            
            var textBox = sender as TextBox;


            if (textBox == null) return;

            textBox.TextChanged -= TextBox_TextChanged;

            if ((bool) e.NewValue)
            {
                HasTextProperty.SetValue(textBox);
                textBox.TextChanged += TextBox_TextChanged;
            }
            

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            HasTextProperty.SetValue((TextBox)sender);
        }

    }

    public class HasTextProperty : BaseAttachedProperty<HasTextProperty, bool>
    {
        public static void SetValue(DependencyObject sender)
        {
            SetValue(sender, ((TextBox)sender).LineCount > 0);
        }
    }
}
