using System.Windows;
using System.Windows.Controls;

namespace customtoolbartype.Helpers
{
    public static class TextBoxHelper
    {
        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.RegisterAttached(
                "Watermark",
                typeof(string),
                typeof(TextBoxHelper),
                new PropertyMetadata(string.Empty, OnWatermarkChanged));

        public static string GetWatermark(DependencyObject obj)
            => (string)obj.GetValue(WatermarkProperty);

        public static void SetWatermark(DependencyObject obj, string value)
            => obj.SetValue(WatermarkProperty, value);

        private static void OnWatermarkChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox)
            {
                textBox.Text = (string)e.NewValue;
                textBox.GotFocus += (sender, args) =>
                {
                    if (textBox.Text == (string)e.NewValue)
                        textBox.Text = string.Empty;
                };
                textBox.LostFocus += (sender, args) =>
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                        textBox.Text = (string)e.NewValue;
                };
            }
        }
    }
}

