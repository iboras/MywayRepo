using MyWay.ViewModelLayer;
using System.Windows;
using System.Windows.Controls;

namespace MyWay.WPF.UserControls
{
    /// <summary>
    /// Interaction logic for UserMaintenanceControl.xaml
    /// </summary>
    public partial class UserMaintenanceControl : UserControl
    {
        private UserMaintenanceViewModel _viewModel = null;
        public UserMaintenanceControl()
        {
            InitializeComponent();
            _viewModel = (UserMaintenanceViewModel)this.Resources["viewModel"];
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Close(true);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.LoadUsers();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.BeginEdit(true);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.BeginEdit(false);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            listControl.DeleteUser();
        }

        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CancelEdit();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Save();
        }
    }
}
