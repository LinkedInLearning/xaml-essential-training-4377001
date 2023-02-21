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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Precedence {
	/// <summary>
	/// Interaction logic for Demo3Window.xaml
	/// </summary>
	public partial class Win3 : Window {
		DispatcherTimer _timer;
		public Win3() {
			InitializeComponent();
			_timer = new DispatcherTimer();
			_timer.Interval = new TimeSpan(0, 0, 0, 0, 200);
			_timer.Tick += Timer_Tick;
			_timer.Start();
		}
		void Timer_Tick(object? sender, EventArgs e) {
			tbResult7.Text = GetPrecedence(AnimatedTextBlock);
			

		}

		private string GetPrecedence(TextBlock current) {
			var source = DependencyPropertyHelper.GetValueSource(current as TextBlock,
																														TextBlock.FontSizeProperty);
			if (source.IsAnimated)
			{
				return "Animated";
			}
			return source.BaseValueSource.ToString();
		}
		private void AnimateButton_Click(object sender, RoutedEventArgs e) {
			Storyboard? sb = this.FindResource("Storyboard1") as Storyboard;

			sb.Begin();

		
		}

	
	}
}
