﻿using MyWay.ViewModelLayer;
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

namespace MyWay.WPF.UserControls
{
    /// <summary>
    /// Interaction logic for RoleControl.xaml
    /// </summary>
    public partial class RoleControl : UserControl
    {
        private readonly RoleViewModel _viewModel = null;
        public RoleControl()
        {
            InitializeComponent();
            _viewModel = (RoleViewModel)this.Resources["viewModel"];
        }
    }
}
