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

namespace CreateCustomDependencyProperty {
	/// <summary>
	/// Interaction logic for StarShape.xaml
	/// </summary>
	public partial class StarShape : UserControl {
		public StarShape() {
			InitializeComponent();
		}

		// To use DependencyProperty the class must derive from DependencyObject
		// most WPF elements have this class somewhere in
		// their class hierarchy

		// 1. declare an variable to represent the DP
		//    This is always an instance of the DependencyProperty class
		//    Info about your property must be available to all of WPF
		//    so make it a static field
		public static readonly DependencyProperty PointsProperty;

		static StarShape() {

			// 2. Register with the DP system
			//PointsProperty = DependencyProperty.Register("Points",
			//								typeof(double), typeof(StarShape), null);

			// readonly properties can only be set
			// in the static constructor

			var meta = new PropertyMetadata(defaultValue: 5.0,
																			propertyChangedCallback: PointsChanged);
			PointsProperty = DependencyProperty.Register(name: "Points",
																									propertyType: typeof(double),
																									ownerType: typeof(StarShape),
																									typeMetadata: meta);



		}
		// Optional
		// Create CLR wrapper for the DP
		// Note that there is NO backing variable
		// Do not put any code in the get/set other 
		// that calls to the GetValue/SetValue 
		public double Points {
			get { return (double)GetValue(PointsProperty); }
			set { SetValue(PointsProperty, value); }
		}

		#region propertychanged
		private static void PointsChanged(object sender, DependencyPropertyChangedEventArgs args) {
			((StarShape)sender).OnPointsChanged(args);

		}
		protected virtual void OnPointsChanged(DependencyPropertyChangedEventArgs e) {

			if ((double)e.NewValue == 6.0)
			{
				star6.Visibility = Visibility.Visible;
				star5.Visibility = Visibility.Collapsed;
			}
			else
			{
				star6.Visibility = Visibility.Collapsed;
				star5.Visibility = Visibility.Visible;
			}
		}

		#endregion

		public static readonly DependencyProperty RadiusProperty;


	}
}
