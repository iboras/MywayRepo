using MyWay.ViewModelLayer;
using MyWay.WPF.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyWay.WPF
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _viewModel = null;
        private readonly string _originalMessage = string.Empty;
        string _tag = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = (MainWindowViewModel)this.Resources["viewModel"];
            _originalMessage = _viewModel.StatusMessage;
            AddHandler(NewControl.ButtonEvent, new RoutedEventHandler(buttonClick_Event));
        }

        private void buttonClick_Event(object sender, RoutedEventArgs e)
        {
            //Button srcButton = e.Source as Button;
            Button srcButton = (Button)e.OriginalSource;
            // The Tag property contains a command 
            // or the name of a user control to load
            if (srcButton.Tag != null)
            {   
                _tag = srcButton.Tag.ToString();
                DynamicLoadManager(_tag);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mnu = (MenuItem)sender; 
            // The Tag property contains a command 
            // or the name of a user control to load
            if (mnu.Tag != null)
            {
                _tag = mnu.Tag.ToString();
                DynamicLoadManager(_tag);
            }
        }
        private bool ShouldLoadUserControl(string controlName)
        {
            bool ret = true;

            // Make sure you don't reload a control already loaded.
            if (contentArea.Children.Count > 0)
            {
                if (((UserControl)contentArea.Children[0]).GetType().Name ==
                    controlName.Substring(controlName.LastIndexOf(".") + 1))
                {
                    ret = false;
                }
            }

            return ret;
        }

        private void LoadUserControl(string controlName)
        {
            Type ucType;
            UserControl uc;

            if (ShouldLoadUserControl(controlName))
            {
                // Create a Type from controlName parameter
                ucType = Type.GetType(controlName);
                if (ucType == null)
                {
                    MessageBox.Show("The Control: " + controlName
                                     + " does not exist.");
                }
                else
                {
                    // Close current user control in content area
                    // NOTE: Optionally add current user control to a list 
                    //     so you can restore it when you close the newly added one
                    CloseUserControl();

                    // Create an instance of this control
                    uc = (UserControl)Activator.CreateInstance(ucType);
                    if (uc != null)
                    {
                        // Display control in content area
                        DisplayUserControl(uc);
                    }
                }
            }
        }
        private void DynamicLoadManager(string tag)
        {
            if (tag.Contains("."))
            {
                // Display a user control
                LoadUserControl(tag);
            }
            else
            {
                // Process special commands
                ProcessMenuCommands(tag);
            }
        }
        private void ProcessMenuCommands(string command)
        {
            switch (command.ToLower())
            {
                case "exit":
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        private void CloseUserControl()
        {
            // Remove current user control
            contentArea.Children.Clear();

            // Restore the original status message
            _viewModel.StatusMessage = _originalMessage;
        }

        public void DisplayUserControl(UserControl uc)
        {
            // Add new user control to content area
            contentArea.Children.Add(uc);
        }
    }
}
