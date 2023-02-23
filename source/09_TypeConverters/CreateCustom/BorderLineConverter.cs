using CreateCustom.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateCustom
{


	public class BorderlineConverter : TypeConverter {
		// TypeConverter is a generalized class, you could create a converter from any type
		// In XAML, the only type coming from the property attribute is a string 
		// should return true if sourceType is string
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
			if (sourceType == typeof(string))
			{
				return true;
			}
			return base.CanConvertFrom(context, sourceType);
		}
		// Do the conversion
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
			if (value != null && value is string)
			{
				var valueString = value.ToString();
				var cleaned = RemoveWhitespace(valueString);
				var results = cleaned.Split(',');

				if (results.Length == 1)
				{
					return new BorderLine
					{
						Left = double.Parse(results[0]),
						Right = double.Parse(results[0]),
						Top = double.Parse(results[0]),
						Bottom = double.Parse(results[0])
					};
				}
				if (results.Length == 2)
				{
					return new BorderLine
					{
						Left = double.Parse(results[0]),
						Right = double.Parse(results[0]),
						Top = double.Parse(results[1]),
						Bottom = double.Parse(results[1])
					};
				}
				if (results.Length == 4)
				{
					return new BorderLine
					{
						Left = double.Parse(results[0]),
						Right = double.Parse(results[2]),
						Top = double.Parse(results[1]),
						Bottom = double.Parse(results[3])
					};
				}
				else
				{
					throw new ArgumentOutOfRangeException(
					"Invalid format for Borderline");
				}

			}
			return base.ConvertFrom(context, culture, value);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
			return base.CanConvertTo(context, destinationType);
		}
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
			return base.ConvertTo(context, culture, value, destinationType);
		}

		public string RemoveWhitespace(string input) {
			return new string(input.ToCharArray()
					.Where(c => !Char.IsWhiteSpace(c))
					.ToArray());
		}
	}
}
