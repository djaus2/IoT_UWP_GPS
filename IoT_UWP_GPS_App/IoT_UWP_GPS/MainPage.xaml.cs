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
using Windows.Devices.Geolocation;

// https://msdn.microsoft.com/en-us/library/windows/apps/jj662935(v=vs.105).aspx
namespace IoT_UWP_GPS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public static Geolocator Geolocator { get; set; }
        public static bool RunningInBackground { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            SetupGeo();
        }

        private void SetupGeo()
        {
            if (Geolocator == null)
            {
                Geolocator = new Geolocator();
                Geolocator.DesiredAccuracy = PositionAccuracy.High;
                Geolocator.MovementThreshold = 100; // The units are meters.
                Geolocator.PositionChanged += Geolocator_PositionChanged;
            }
        }

        private void Geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            geolocator_PositionChanged(sender, args);
        }

        private   async void  geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
             await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {   //Point point;
                //point.Position.Latitude
                LatitudeTextBlock.Text = args.Position.Coordinate.Latitude.ToString("0.00");
                LongitudeTextBlock.Text = args.Position.Coordinate.Longitude.ToString("0.00");
            });

        }
    }
}
