using MyWay.Model.Entitys;
using MyWay.ViewModelLayer;
using System.Windows;
using System.Windows.Controls;

namespace MyWay.WPF.UserControls
{
    /// <summary>
    /// Interaction logic for UserMaintenanceListControl.xaml
    /// </summary>
    public partial class UserMaintenanceListControl : UserControl
    {
        public UserMaintenanceListControl()
        {
            InitializeComponent();
        }

        private UserMaintenanceViewModel _viewModel;

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // Set selected item
            _viewModel.Entity = (User)((Button)sender).Tag;
            // Go into Edit mode
            _viewModel.BeginEdit(false);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Set selected item
            _viewModel.Entity = (User)((Button)sender).Tag;
            // Delete user
            DeleteUser();
        }

        public void DeleteUser()
        {
            // Ask if the user wants to delete this user
            if (MessageBox.Show("Delete User " + _viewModel.Entity.UserLastName + ", " + _viewModel.Entity.UserFirstName + "?", "Delete?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _viewModel.Delete();
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel = (UserMaintenanceViewModel)this.DataContext;
        }
    }
}
