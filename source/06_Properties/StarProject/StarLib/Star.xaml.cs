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

namespace StarLib.Shapes {

	public partial class Star : UserControl {

		public Star() {
			InitializeComponent();
		}

		// To use DependencyProperty the class must derive from DependencyObject
		// most WPF elements have this class somewhere in
		// their class hierarchy

		// 1. declare an public field
		//    of DependencyProperty type

		// By defining DP with static keyword it can be shared across multiple instances of a class.
		// This means that the property is not tied to a specific instance of the class,
		// but rather to the class itself.
		public static readonly DependencyProperty InnerSizeProperty;

		public static readonly DependencyProperty PointsPropery;
		public static readonly DependencyProperty BackEffectVisibleProperty;
		public static readonly DependencyProperty MessageProperty;

		static Star() {
			// 2. Register with the DP system
			// PointsProperty = DependencyProperty.Register("Points",
			//								  typeof(double), typeof(StarShape), null);

			// read-only properties can only be set
			// in the static constructor

			var meta = new PropertyMetadata(defaultValue: 8,
																	propertyChangedCallback: PointsChanged);
			PointsPropery = DependencyProperty.Register(name: "Points",
																									propertyType: typeof(int),
																									ownerType: typeof(Star),
																									typeMetadata: meta);
			
			var meta2 = new PropertyMetadata(defaultValue: 1.0,
																	propertyChangedCallback: InnerSizeChanged);
			InnerSizeProperty = DependencyProperty.Register(name: "InnerSize",
																									propertyType: typeof(double),
																									ownerType: typeof(Star),
																									typeMetadata: meta2);


			var meta3 = new PropertyMetadata(defaultValue: true,
														propertyChangedCallback: BackEffectVisibleChanged);
			BackEffectVisibleProperty = DependencyProperty.Register(name: "BackEffectVisible",
																									propertyType: typeof(bool),
																									ownerType: typeof(Star),
																									typeMetadata: meta3);

			var meta4 = new PropertyMetadata(defaultValue: String.Empty,
														propertyChangedCallback: MessageChanged);
			MessageProperty = DependencyProperty.Register(name: "MessageProperty",
																									propertyType: typeof(string),
																									ownerType: typeof(Star),
																									typeMetadata: meta4);
		}



		#region Points

		// Optional
		// Create CLR wrapper for the DP
		// Note that there is NO backing variable
		// Do not put any code in the get/set other 
		// that calls to the GetValue/SetValue 
		public int Points
		{
			get { return (int)GetValue(PointsPropery); }
			set { SetValue(PointsPropery, value); }
		}

		#region Points Property Changed
		private static void PointsChanged(object sender, DependencyPropertyChangedEventArgs args) {
			((Star)sender).OnStarburstVisibleChanged(args);

		}
		protected virtual void OnStarburstVisibleChanged(DependencyPropertyChangedEventArgs e) {

			int pointCount = Math.Min((int)e.NewValue, 10);
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


		#region InnerSize

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

		#region BackEffectVisible

		public bool BackEffectVisible
		{
			get { return (bool)GetValue(BackEffectVisibleProperty); }
			set { SetValue(BackEffectVisibleProperty, value); }
		}

		#region BackEffectVisible Property Changed
		private static void BackEffectVisibleChanged(object sender, DependencyPropertyChangedEventArgs args) {
			((Star)sender).OnBackEffectVisible(args);

		}
		protected virtual void OnBackEffectVisible(DependencyPropertyChangedEventArgs e) {

			bool IsVisible = (bool)e.NewValue;

			if (IsVisible)
			{
				BackCircle.Visibility = Visibility.Visible;
			}
			else
			{
				BackCircle.Visibility = Visibility.Collapsed;
			}




		}

		#endregion

		#endregion



		#region Message

		public string Message
		{
			get { return (string)GetValue(MessageProperty); }
			set { SetValue(MessageProperty, value); }
		}


		private static void MessageChanged(object sender, DependencyPropertyChangedEventArgs args) {
			((Star)sender).OnMessageChanged(args);

		}
		protected virtual void OnMessageChanged(DependencyPropertyChangedEventArgs e) {

			string message = e.NewValue.ToString();
			MessageTextBlock.Text = message;
		}



		#endregion
	}
}
