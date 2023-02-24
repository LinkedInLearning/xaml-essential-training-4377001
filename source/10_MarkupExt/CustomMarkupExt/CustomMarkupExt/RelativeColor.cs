using System;
using System.Windows.Markup;
using System.Windows.Media;

namespace CustomMarkupExt {

	[MarkupExtensionReturnType(typeof(Brush))]
	internal class RelativeColor : MarkupExtension {
		private Color _color = Colors.Orange;

		// use a hard coded color
		public RelativeColor() {
		}
		//public Color Color
		//{
		//	get { return _color; }
		//	set { _color = value; }
		//}
		public override object ProvideValue(IServiceProvider serviceProvider) {
			return new SolidColorBrush(_color);
		}
	}
}