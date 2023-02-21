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

namespace Precedence {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}

		private void FirstDemoButton_Click(object sender, RoutedEventArgs e) {
			(new Win1()).Show();
		}

		private void SecondDemoButton_Click(object sender, RoutedEventArgs e) {
			(new Win2()).Show();
		}

		private void ThirdDemoButton_Click(object sender, RoutedEventArgs e) {
			(new Win3()).Show();
		}
	}
}
