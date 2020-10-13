using System.Windows;
using System.Windows.Controls;

namespace MyWay.WPF.UserControls
{
    /// <summary>
    /// Interaction logic for NewControl.xaml
    /// </summary>
    public partial class NewControl : UserControl
    {
        public NewControl()
        {
            InitializeComponent();

        }

        public static readonly RoutedEvent ButtonEvent = EventManager.RegisterRoutedEvent("ButtonClicl_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(NewControl));

        public event RoutedEventHandler RoutedButtonEvent 
        {
            add { AddHandler(NewControl.ButtonEvent, value); }

            remove { RemoveHandler(NewControl.ButtonEvent, value); }
        }

        //raise the relevant event in an appropriate method. 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           RaiseEvent(new RoutedEventArgs(NewControl.ButtonEvent, sender));
        }
    }
}
