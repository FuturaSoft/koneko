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

namespace Koneko
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Configuration config = new Configuration();
            try
            {
                Uri applicationUri = new Uri(config.applicationUrl);
                this.webview_main.Navigate(applicationUri);
            }
            catch (FormatException ex)
            {
                this.DisplayBadUriDialog();
            }
        }

        private async void DisplayBadUriDialog()
        {
            ContentDialog badUriDialog = new ContentDialog
            {
                Title = "Bad URI",
                Content = "URI defined have a bad format.",
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await badUriDialog.ShowAsync();
        }
    }
}
