﻿using System;
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
using System.Windows.Shapes;

namespace Content101.ItemsControls {
	/// <summary>
	/// Interaction logic for DataBindGrid.xaml
	/// </summary>
	public partial class DataBindGrid : Window {
		public DataBindGrid() {
			InitializeComponent();
		}

		private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }
    }
}