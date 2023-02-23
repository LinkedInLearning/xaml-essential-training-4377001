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
using WhyTypeConverters.Controls;

namespace CreateCustom.Controls {
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
		public BorderLine StarBorder
		{
			get { return (BorderLine)GetValue(StarBorderProperty); }
			set { SetValue(StarBorderProperty, value); }
		}


		public static readonly DependencyProperty StarBorderProperty;


		static Rating() {

			var meta = new PropertyMetadata(defaultValue: null,
																			propertyChangedCallback: BorderChanged);
			StarBorderProperty = DependencyProperty.Register(name: "StarBorder",
																											 propertyType: typeof(BorderLine),
																											ownerType: typeof(Rating),
																											typeMetadata: meta);
		}

	
		private static void BorderChanged(object sender, DependencyPropertyChangedEventArgs args) {
			((Rating)sender).OnBorderChanged(args);

		}
		protected virtual void OnBorderChanged(DependencyPropertyChangedEventArgs e) {
			
 			ResultTextBlock.Text = e.NewValue.ToString();

		}

	}
}
