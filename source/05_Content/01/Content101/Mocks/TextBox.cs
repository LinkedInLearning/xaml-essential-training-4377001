using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace Content101.Mocks {

	[ContentProperty("Text")]
	internal class TextBox {
		public int SelectionLength { get; set; }
		public string Text { get; set; }
		public TextWrapping Wrap { get; set; }
		public TextAlignment Alignment { get; set; }
		public int LineCount { get; set; }
		// 20 additional properties
	}
}
