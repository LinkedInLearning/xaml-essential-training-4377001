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
using System.Windows.Shapes;

namespace PropertyAttributes {
  /// <summary>
  /// Interaction logic for CreateInCode.xaml
  /// </summary>
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

      elip.Width = 200;
      elip.Height = 160;
      elip.Fill = new SolidColorBrush(Colors.Goldenrod);
      elip.Opacity = .7;

      // rect.Margin = "20,10,20,-10"; // this won't work

      rect.Margin = new Thickness(20,10,20,-10);
    }
  }
}
