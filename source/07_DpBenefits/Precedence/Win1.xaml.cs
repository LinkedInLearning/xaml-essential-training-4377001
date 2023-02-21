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
using System.Windows.Threading;

namespace Precedence {
	/// <summary>
	/// Interaction logic for Wind1.xaml
	/// </summary>
	public partial class Win1 : Window {
		DispatcherTimer _timer;
		public Win1() {
			InitializeComponent();
			_timer = new DispatcherTimer();
			_timer.Interval = new TimeSpan(0, 0, 0, 0, 200);

			_timer.Tick += Timer_Tick;
			_timer.Start();
		}

		private void Timer_Tick(object? sender, EventArgs e) {
			tbResult1.Text = GetPrecedence(tb1);
			tbResult3.Text = GetPrecedence(tb3);
			tbResult2.Text = GetPrecedence(tb2);
		}


		private string GetPrecedence(TextBlock current) {
			var source = DependencyPropertyHelper.GetValueSource(current as TextBlock,
																														TextBlock.FontWeightProperty).BaseValueSource;
			return source.ToString();
		}
	}
}
