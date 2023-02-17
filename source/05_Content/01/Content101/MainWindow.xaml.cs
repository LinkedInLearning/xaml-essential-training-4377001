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

namespace Content101 {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}

		private void Inlines_Click(object sender, RoutedEventArgs e) {
			(new Windows.TextBlockInlines()).Show();
		}

		private void PanelsButton_Click(object sender, RoutedEventArgs e) {
			(new Windows.PanelsExample()).Show();
		}

		private void DockPanelButton_Click(object sender, RoutedEventArgs e) {
			(new Windows.DockPanelExample()).Show();
		}

		private void ItemsControlButton_Click(object sender, RoutedEventArgs e) {
			(new Windows.ItemsControlExample()).Show();
		}

		private void BindListsButton_Click(object sender, RoutedEventArgs e) {
			(new Windows.DataBindLists()).Show();
		}

		private void BindGridButton_Click(object sender, RoutedEventArgs e) {
			(new Windows.DataBindGrid()).Show();
		}

		private void ListItemButton_Click(object sender, RoutedEventArgs e) {
			(new Windows.ListItemExample()).Show();
		}

		private void ContentControlButton_Click(object sender, RoutedEventArgs e) {
			(new Windows.ContentControlsExample()).Show();
		}

		private void DecoratorButton_Click(object sender, RoutedEventArgs e) {
			(new Windows.DecoratorExample()).Show();
		}

		private void NonUiButton_Click(object sender, RoutedEventArgs e) {
			(new Windows.NonUiContent()).Show();
		}

		private void ContentServiceButton_Click(object sender, RoutedEventArgs e) {
			(new Windows.ContentServices()).Show();
		}
	}
}
