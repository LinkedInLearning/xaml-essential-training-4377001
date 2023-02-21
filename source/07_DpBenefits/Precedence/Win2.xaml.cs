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
	/// Interaction logic for Demo2Window.xaml
	/// </summary>
	public partial class Win2 : Window {
		DispatcherTimer _timer;
		public Win2() {
			InitializeComponent();
			_timer = new DispatcherTimer();
			_timer.Interval = new TimeSpan(0, 0, 0, 0, 200);
			_timer.Tick += new EventHandler(Timer_Tick);
			_timer.Start();
		}
		void Timer_Tick(object? sender, EventArgs e) {
			tbResult4.Text = GetPrecedence(tb4);
			tbResult5.Text = GetPrecedence(tb5);
			tbResult6.Text = GetPrecedence(tb6);

		}

		private string GetPrecedence(TextBlock current) {
			var source = DependencyPropertyHelper.GetValueSource(current as TextBlock,
																														TextBlock.BackgroundProperty).BaseValueSource;
			return source.ToString();
		}
	}
}
