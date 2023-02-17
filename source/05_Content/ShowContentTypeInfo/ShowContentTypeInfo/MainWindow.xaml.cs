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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShowContentTypeInfo {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
			Type t = typeof(System.Windows.Controls.TextBlock);
			Assembly assembly = t.Assembly;
			var custAttr = from type in assembly.GetTypes()
										 where type.IsSubclassOf(typeof(System.Windows.UIElement))
										 orderby type.Name

										 let ContentAttributes = ((ContentPropertyAttribute[])type.GetCustomAttributes(typeof(ContentPropertyAttribute), true)).ToList()

										 where ContentAttributes.Count() > 0
										 where type.IsAbstract == false

										 let attributeItems = ContentAttributes[0]
										 where attributeItems.Name != null
										 let x = type.GetProperty(attributeItems.Name)
										 let message = $"<{type.Name}>{Environment.NewLine}    {x.PropertyType.Name} ◄ {Environment.NewLine}</{type.Name}>"
										 select new { UIElementName = type.Name, ContentPropName = attributeItems.Name, PropertyType = x.PropertyType.Name, XamlExample = message };

			this.DataContext = custAttr.ToList();
		}
	}
}
