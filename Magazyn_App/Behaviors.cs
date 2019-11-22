using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace Magazyn_App
{
    public class WindowCloseBehavior : Behavior<Window>
    {


        public Button ButtonControl
        {
            get { return (Button)GetValue(ButtonProperty); }
            set { SetValue(ButtonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonProperty =
            DependencyProperty.Register("ButtonControl", typeof(Button), typeof(WindowCloseBehavior), new PropertyMetadata(null, ButtonPropertyChanged));

        private static void ButtonPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Window window = (d as WindowCloseBehavior).AssociatedObject;
            RoutedEventHandler button_Click = (object sender, RoutedEventArgs _e) => { window.Close(); };
            if (e.OldValue != null)
                ((Button)e.OldValue).Click -= button_Click;
            if (e.NewValue != null)
                ((Button)e.NewValue).Click += button_Click;
        }
    }
}
