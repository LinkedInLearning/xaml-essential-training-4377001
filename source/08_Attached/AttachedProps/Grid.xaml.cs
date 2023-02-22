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

namespace AttachedProps
{
    /// <summary>
    /// Interaction logic for GridExample.xaml
    /// </summary>
    public partial class GridExample : Window
    {
        public GridExample()
        {
            InitializeComponent();
        }

		private void MoveButton_Click(object sender, RoutedEventArgs e) {
      Grid.SetColumn(Circle1, 0);
			Grid.SetRow(Circle1, 2);
		}
	}
}
