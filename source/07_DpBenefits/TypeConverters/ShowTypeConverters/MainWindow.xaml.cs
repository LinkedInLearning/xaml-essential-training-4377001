using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace ShowTypeConverters {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
			Type t1 = typeof(System.ComponentModel.ByteConverter);
			var assembly1 = t1.Assembly;
			Type t2 = typeof(System.Windows.Media.Brush);
			var assembly2 = t2.Assembly;

			Type t3 = typeof(System.Windows.FontSizeConverter);
			var assembly3 = t3.Assembly;


			var q1 = from type in assembly1.GetTypes()
							where type.IsSubclassOf(typeof(System.ComponentModel.TypeConverter))
							orderby type.Name
							let ShortName = type.Name.Remove(type.Name.LastIndexOf("Converter"))
							select ShortName;


			var q2 = from type in assembly2.GetTypes()
							 where type.IsSubclassOf(typeof(System.ComponentModel.TypeConverter))
							 orderby type.Name
							 let ShortName = type.Name.Remove(type.Name.LastIndexOf("Converter"))
							 select ShortName; ;

			var q3 = from type in assembly3.GetTypes()
							 where type.IsSubclassOf(typeof(System.ComponentModel.TypeConverter))
							 orderby type.Name
							 let ShortName = type.Name.Remove(type.Name.LastIndexOf("Converter"))
							 select ShortName; ;
			var result = q2.ToList();
			result.AddRange(q3.ToList());
	
			this.TypeConvertersListBox.DataContext = q2.ToList().OrderBy(t => t);
			this.BasicConvertersListBox.DataContext = q1.ToList().OrderBy(t => t);
			this.BrushConvertersListBox.DataContext = q3.ToList().OrderBy(t => t);
		}

		private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
			var currentListBox = sender as ListBox;
			ShowListBox.Items.Add(currentListBox.SelectedItem);
		}
	}
}

