
using AttachedProps.Windows;
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

namespace AttachedProps {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}

		private void PolarPanelButton_Click(object sender, RoutedEventArgs e) {
			(new UsePolar()).Show();
		}

		private void KeyNavButton_Click(object sender, RoutedEventArgs e) {
			(new KeyNav()).Show();
		}

		private void TooltipButton_Click(object sender, RoutedEventArgs e) {
			(new TooltipExample()).Show();
		}
	}
}
