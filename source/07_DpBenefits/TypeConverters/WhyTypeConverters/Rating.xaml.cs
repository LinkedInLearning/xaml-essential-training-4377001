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

namespace WhyTypeConverters.Controls {
	/// <summary>
	/// Interaction logic for Rating.xaml
	/// </summary>
	public partial class Rating : UserControl {
		public Rating() {
			InitializeComponent();
	
		}


		// A real UI element
		// should use Dependency Properties 

		// For simplification, this example uses .NET properties only
		public string HeaderText { get; set; }
		public int StarCount { get; set; }
		public double UserRating { get; set; }
		public Brush StarBackground { get; set; }
		public Brush StarStroke { get; set; }
		public BorderLine StarBorder { get; set; }


	}
	// created for the example
	// for a real control, use the Thickness type
	public class BorderLine {
		public double Top { get; set; }
		public double Bottom { get; set; }
		public double Left { get; set; }
		public double Right { get; set; }
	}
}
