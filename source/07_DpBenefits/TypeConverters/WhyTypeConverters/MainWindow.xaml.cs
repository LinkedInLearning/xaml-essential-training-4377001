using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WhyTypeConverters.Controls;

namespace WhyTypeConverters {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		
			SetPropertiesInCode();
		}

		public void SetPropertiesInCode() {
			var cardRating = new Rating();

			cardRating.HeaderText = "How would you rate your buying experience?";
			cardRating.StarCount = 5;
			cardRating.StarCount = int.Parse("7");
			cardRating.UserRating = double.Parse("3.5");
			// or use the DoubleConverter class
			var doubleConv = new DoubleConverter	();
			cardRating.UserRating = (double)doubleConv.ConvertFromString("2.5");

			// cardRating.StarBackground = "Red"; // won't work, need to convert to a brush
			var brushConv = new BrushConverter();

			cardRating.StarBackground = brushConv.ConvertFromString("Orange") as SolidColorBrush;
			
		}

		private void currentRating_MouseEnter(object sender, MouseEventArgs e) {
		
		}
	}
}
