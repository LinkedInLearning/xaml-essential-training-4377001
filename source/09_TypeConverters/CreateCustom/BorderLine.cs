using System.ComponentModel;

namespace CreateCustom.Controls {
	// created for the example
	// for a real control, use the Thickness type

	//[TypeConverter(typeof(BorderlineConverter))]
	public class BorderLine {
		public double Top { get; set; }
		public double Bottom { get; set; }
		public double Left { get; set; }
		public double Right { get; set; }
		public override string ToString() {
			return $"Left: {Left}  Top: {Top}  Right: {Right}  Bottom: {Bottom}";
		}
	}
}
