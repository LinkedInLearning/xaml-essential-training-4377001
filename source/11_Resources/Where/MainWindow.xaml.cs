using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WhereResource {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();

      var dictionary = new ResourceDictionary();

      dictionary.Add(key: "MainBrush", value: new SolidColorBrush(Colors.Lavender));
      dictionary.Add(key: "AccentBrush", value: new SolidColorBrush(Colors.Gold));



      this.Resources = dictionary;


    }
  }
}
