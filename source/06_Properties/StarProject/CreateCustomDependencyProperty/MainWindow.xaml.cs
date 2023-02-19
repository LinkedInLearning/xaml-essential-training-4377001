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
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e) {
		//	BottomStar.Points = 5;
     // BottomStar.SetValue(StarShape.PointsProperty, 6);
     
		}

		private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
			TheStar.Points = (int)e.NewValue;
		}

		private void InnerSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
			TheStar.InnerSize = (double)e.NewValue;
		}

		private void ForegroundRectangle_MouseUp(object sender, MouseButtonEventArgs e) {

			var currentRect = sender as Rectangle;
			if (currentRect != null)
			{

				TheStar.Foreground = currentRect.Fill;
			}

		}

		private void BackgroundRectangle_MouseUp(object sender, MouseButtonEventArgs e) {
			var currentRect = sender as Rectangle;
			if (currentRect != null)
			{

				TheStar.Background = currentRect.Fill;
			}
		}
	}
}
