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

namespace BigStar.Lib.Controls {
	/// <summary>
	/// Interaction logic for Gauge.xaml
	/// </summary>
	public partial class Gauge : UserControl {
		public Gauge() {
			InitializeComponent();
		}

		#region Degree
		/// <summary>
		/// Degree Dependency Property
		/// </summary>
		public static readonly DependencyProperty DegreeProperty =
				DependencyProperty.Register(
						"Degree",
						typeof(double),
						typeof(Gauge),
						new PropertyMetadata(0d, OnDegreeChanged));

		/// <summary>
		/// Gets or sets the Degree property. This dependency property 
		/// indicates ....
		/// </summary>
		public double Degree {
			get { return (double)GetValue(DegreeProperty); }
			set { SetValue(DegreeProperty, value); }
		}

		/// <summary>
		/// Handles changes to the Degree property.
		/// </summary>
		/// <param name="d">
		/// The <see cref="DependencyObject"/> on which
		/// the property has changed value.
		/// </param>
		/// <param name="e">
		/// Event data that is issued by any event that
		/// tracks changes to the effective value of this property.
		/// </param>
		private static void OnDegreeChanged(
				DependencyObject d, DependencyPropertyChangedEventArgs e) {
			var target = (Gauge)d;
			double oldDegree = (double)e.OldValue;
			double newDegree = target.Degree;
			target.OnDegreeChanged(oldDegree, newDegree);
		}

		/// <summary>
		/// Provides derived classes an opportunity to handle changes
		/// to the Degree property.
		/// </summary>
		/// <param name="oldDegree">The old Degree value</param>
		/// <param name="newDegree">The new Degree value</param>
		private void OnDegreeChanged(
				double oldDegree, double newDegree) {
			GridTransform.Angle = newDegree;
			DegreeString = newDegree.ToString() + " º";

		}
		#endregion

		#region DegreeString
		/// <summary>
		/// DegreeString Dependency Property
		/// </summary>
		public static readonly DependencyProperty DegreeStringProperty =
				DependencyProperty.Register(
						"DegreeString",
						typeof(string),
						typeof(Gauge),
						new PropertyMetadata("0"));

		/// <summary>
		/// Gets or sets the DegreeString property. This dependency property 
		/// indicates ....
		/// </summary>
		public string DegreeString {
			get { return (string)GetValue(DegreeStringProperty); }
			set { SetValue(DegreeStringProperty, value); }
		}
		#endregion
	}
}
