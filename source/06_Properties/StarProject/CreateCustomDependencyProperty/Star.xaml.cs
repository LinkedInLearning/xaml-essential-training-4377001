using System;
using System.Collections;
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

	public partial class Star : UserControl {
		public enum StarPoints {
			Default = 8,
			Two = 2,
			Three = 3,
			Four = 4,
			Six = 6,
			Eight = 8,
			Ten = 10,
			Twelve = 12
		}
		public Star() {
			InitializeComponent();
		}

		public static readonly DependencyProperty InnerSizeProperty;
		public static readonly DependencyProperty PointsPropery;

		static Star() {
			var meta = new PropertyMetadata(defaultValue: 1.0,
																		propertyChangedCallback: InnerSizeChanged);
			InnerSizeProperty = DependencyProperty.Register(name: "InnerSize",
																									propertyType: typeof(double),
																									ownerType: typeof(Star),
																									typeMetadata: meta);

			var meta2 = new PropertyMetadata(defaultValue: 8,
																	propertyChangedCallback: PointsChanged);
			PointsPropery = DependencyProperty.Register(name: "Points",
																									propertyType: typeof(int),
																									ownerType: typeof(Star),
																									typeMetadata: meta2);
		}

		#region InnerSize
		// Optional
		// Create CLR wrapper for the DP
		// Note that there is NO backing variable
		// Do not put any code in the get/set other 
		// that calls to the GetValue/SetValue 
		public double InnerSize
		{
			get { return (double)GetValue(InnerSizeProperty); }
			set { SetValue(InnerSizeProperty, value); }
		}

		#region Property Changed
		private static void InnerSizeChanged(object sender, DependencyPropertyChangedEventArgs args) {
			((Star)sender).OnInnerSizeChanged(args);

		}
		protected virtual void OnInnerSizeChanged(DependencyPropertyChangedEventArgs e) {

			var newValue = (double)e.NewValue;
			if (newValue < 0)
			{
				InnerSize = Math.Abs(newValue);
			}
			var render = SmallGrid.RenderTransform as TransformGroup;
			var scale = render.Children.OfType<ScaleTransform>().First();
			scale.ScaleX = scale.ScaleY = newValue;



		}

		#endregion

		#endregion

		#region Points

		public int Points
		{
			get { return (int)GetValue(PointsPropery); }
			set { SetValue(PointsPropery, value); }
		}

		#region Points Property Changed
		private static void PointsChanged(object sender, DependencyPropertyChangedEventArgs args) {
			((Star)sender).OnPointsChanged(args);

		}
		protected virtual void OnPointsChanged(DependencyPropertyChangedEventArgs e) {

			int pointCount = Math.Min((int)e.NewValue, 12);
			pointCount = Math.Max((int)e.NewValue, 2);
	

			double angle = 180 / pointCount;
			double angleCounter = 0;
			var allBigEllipse = BigGrid.Children.OfType<Ellipse>();
			var selectBigEllipses = BigGrid.Children.OfType<Ellipse>().Take(pointCount);

			var allSmallEllipse = SmallGrid.Children.OfType<Ellipse>();
			var selectSmallEllipses = SmallGrid.Children.OfType<Ellipse>().Take(pointCount);

			foreach (var elip in allBigEllipse)
			{
				elip.Visibility = Visibility.Collapsed;
			}
			foreach (var elip in allSmallEllipse)
			{
				elip.Visibility = Visibility.Collapsed;
			}
			angleCounter = 0;
			foreach (var elip in selectBigEllipses)
			{

				elip.Visibility = Visibility.Visible;
				var render = elip.RenderTransform as TransformGroup;
				var rot = render.Children.OfType<RotateTransform>().First();
				rot.Angle = angleCounter;
				angleCounter += angle;
			}
			var offset = angle / 2;
			angleCounter = 0 + offset;
			foreach (var elip in selectSmallEllipses)
			{

				elip.Visibility = Visibility.Visible;
				var render = elip.RenderTransform as TransformGroup;
				var rot = render.Children.OfType<RotateTransform>().First();
				rot.Angle = angleCounter;
				angleCounter += angle;
			}

		}

		#endregion

		#endregion


	}
}
