using System;
using System.Windows.Markup;
using System.Windows.Media;

namespace AddProperties {

	[MarkupExtensionReturnType(typeof(Brush))]
	internal class RelativeColorBrushExtension : MarkupExtension {
		private Color _color = Colors.Orange;
		private ColorAction _colorAction = ColorAction.Normal;

		public RelativeColorBrushExtension() { }

		public Color Color
		{
			get { return _color; }
			set { _color = value; }
		}

		public ColorAction ColorAction
		{
			get { return _colorAction; }
			set { _colorAction = value; }
		}

		public override object ProvideValue(IServiceProvider serviceProvider) {
			var newColor = _colorAction switch
			{
				ColorAction.Lighten => new SolidColorBrush(LightenColor(_color)),
				ColorAction.Darken => new SolidColorBrush(DarkenColor(_color)),
				ColorAction.Normal => new SolidColorBrush(_color),
				_ => new SolidColorBrush(_color)
			};
			return newColor;
		}

		private Color LightenColor(Color currentColor) {
			var hsl = new ColorLib.HslColor(currentColor);
			return hsl.Lighten(.3).ToRgb();
		}

		private Color DarkenColor(Color currentColor) {
			var hsl = new ColorLib.HslColor(currentColor);
			return hsl.Darken(.2).ToRgb();
		}
	}

	public enum ColorAction {
		Normal,
		Lighten,
		Darken
	}
}