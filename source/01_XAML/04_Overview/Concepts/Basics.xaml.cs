using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Concepts {
	/// <summary>
	/// Interaction logic for Basics.xaml
	/// </summary>
	public partial class Basics : Window {
		public Basics() {
			InitializeComponent();

// C# code
var stack = new StackPanel();
var titleText = new TextBlock();
titleText.Text = "Tour Stops";

var kids = new CheckBox();
kids.IsChecked = true;
kids.Content = "Kid Friendly";

stack.Children.Add(titleText);
stack.Children.Add(kids);


		}
	}
}
