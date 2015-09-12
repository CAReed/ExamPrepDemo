using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ExamPrepDemo
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();
		}

		private void TogglePaneButton_Checked(object sender, RoutedEventArgs e)
		{

		}

		private void BackButton_Click(object sender, RoutedEventArgs e)
		{
			bool ignored = false;

			this.BackRequested(ref ignored);
		}

		private void BackRequested(ref bool handled)
		{
			if (this.frame == null)
			{
				return;
			}

			if (this.frame.CanGoBack && !handled)
			{
				handled = true;

				this.frame.GoBack();
			}
		}

		private void OnNavigatingToPage(object sender, NavigatingCancelEventArgs e)
		{
		}

		private void OnNavigatedToPage(object sender, NavigationEventArgs e)
		{
			if (e.Content is Page && e.Content != null)
			{
				var control = (Page)e.Content;

				control.Loaded += Page_Loaded;
			}
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			((Page)sender).Focus(FocusState.Programmatic);
			((Page)sender).Loaded -= Page_Loaded;
		}
	}
}