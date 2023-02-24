using System;
using System.Windows.Markup;
using System.Windows.Media;

namespace CustomMarkupExt {

	// Naming convention is to use the suffix Extension on the type name
	// However, the shorter name can be used in the XAML
	[MarkupExtensionReturnType(typeof(Brush))]
	internal class RelativeColorBrushExtension : MarkupExtension {
		private Color _color = Colors.Orange;

		// use a hard coded color
		public RelativeColorBrushExtension() {
		}

		public override object ProvideValue(IServiceProvider serviceProvider) {
			return new SolidColorBrush(_color);
		}
	}
}