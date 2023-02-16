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

namespace PropertyAttributes {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    private void TitleTextBlock_ToolTipOpening(object sender, ToolTipEventArgs e) {
     
    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {

    }

    private void TourListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
      var item = TourListBox.SelectedItem as ListBoxItem;
      string message = String.Format($"You'll love our {item.Content.ToString()} tour ");
      MessageTextBlock.Text = message;
    }

    private void Button_Click(object sender, RoutedEventArgs e) {
      var b = sender as Button;
      if (b!= null)
      {
        MessageTextBlock.Text = b.Content.ToString();
      }
     

    }

    private void Rectangle_MouseMove(object sender, MouseEventArgs e) {
      string message = String.Format($"{e.GetPosition(this).X}-{e.GetPosition(this).Y}");
      MessageTextBlock.Text = message;
    }
  }
}
