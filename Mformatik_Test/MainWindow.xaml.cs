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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;

namespace Mformatik_Test
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	/// 
	

	public partial class MainWindow : Window
    {
		public static MainWindow from_v = null;
		public MainWindow()
        {
            InitializeComponent();
			from_v = this;
			new MformaticClass();

		}

	}

	public class MformaticClass : Window
    {
		public Timer wait_ten_Timer, wait_two_min_Timer; // create the timers variables to work with
		public MformaticClass()
        {
			write_msg_time(); // show the message function to print hellow with the current time
			set_ten_timer(); // the function work is disappear the message after 10s from appeared
		}
		public void set_ten_timer()
		{
			wait_ten_Timer = new System.Timers.Timer(5000); // set the timer to 10 s
			wait_ten_Timer.Elapsed += disappear_msg_Event; // this line work is after 10 later call the function to disapared the message ...
														   // ... and call another function to appeared the message after 2min later
			wait_ten_Timer.AutoReset = true;
			wait_ten_Timer.Enabled = true;

		}

		public void set_tow_min_timer()
		{
			wait_two_min_Timer = new System.Timers.Timer(10000); // set the timer to 2 min
			wait_two_min_Timer.Elapsed += appear_msg_Event;
			wait_two_min_Timer.AutoReset = true;
			wait_two_min_Timer.Enabled = true;
		}


		public void write_msg_time()
		{
			MainWindow.from_v.message_label.Content = "hellow " + DateTime.Now.ToString("MMMM dd, yyyy") + ".";
		}

		public void disappear_msg_Event(Object source, ElapsedEventArgs e)
		{
			this.Dispatcher.Invoke(() =>
			{
				MainWindow.from_v.message_label.Content = String.Empty;
				wait_ten_Timer.Stop(); // stop the timer
				wait_ten_Timer.Dispose(); // dispose the timer
				set_tow_min_timer();
			});

		}
		public void appear_msg_Event(Object source, ElapsedEventArgs e)
		{
			this.Dispatcher.Invoke(() =>
			{
				write_msg_time();
				wait_two_min_Timer.Stop(); // stop the timer
				wait_two_min_Timer.Dispose(); // dispose the timer
				set_ten_timer();
			});

		}
	}
}
