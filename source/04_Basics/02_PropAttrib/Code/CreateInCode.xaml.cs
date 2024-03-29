﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PropertyAttributes {
	public partial class CreateInCode : Window {
		public CreateInCode() {
			InitializeComponent();

			// instantiate the classes
			var stack = new StackPanel();
			var rect = new Rectangle();
			var elip = new Ellipse();

			// add to the parent Content

			this.Content = stack;
			stack.Children.Add(rect);
			stack.Children.Add(elip);

			rect.Width = 60;
			rect.Height = 90;
			// rect.Fill = "Green"; // this won't work, 
			rect.Fill = new SolidColorBrush(Colors.Green);
			rect.Stroke = new SolidColorBrush(Colors.LightGreen);
			rect.StrokeThickness = 3;
			rect.StrokeDashArray = new DoubleCollection() { 6, 3 };

			elip.Width = 200;
			elip.Height = 160;
			elip.Fill = new SolidColorBrush(Colors.Goldenrod);
			elip.Opacity = .7;

			// elip.Margin = "20,10,20,-10"; // this won't work

			elip.Margin = new Thickness(20, -40, 20, 20);
		}
	}
}
