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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ImagePerf
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public string ImageUrl
        {
            get { return (string)GetValue(ImageUrlProperty); }
            set { SetValue(ImageUrlProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageUrl.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageUrlProperty =
            DependencyProperty.Register("ImageUrl", typeof(string), typeof(MainPage), new PropertyMetadata("http://placecage.com/1920/1080"));


        public Uri ImageUri
        {
            get { return (Uri)GetValue(ImageUriProperty); }
            set { SetValue(ImageUriProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageUri.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageUriProperty =
            DependencyProperty.Register("ImageUri", typeof(Uri), typeof(MainPage), new PropertyMetadata(DependencyProperty.UnsetValue));


        public string DecodeWidth
        {
            get { return (string)GetValue(DecodeWidthProperty); }
            set { SetValue(DecodeWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DecodeWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DecodeWidthProperty =
            DependencyProperty.Register("DecodeWidth", typeof(string), typeof(MainPage), new PropertyMetadata("160"));

        public string DecodeHeight
        {
            get { return (string)GetValue(DecodeHeightProperty); }
            set { SetValue(DecodeHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DecodeHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DecodeHeightProperty =
            DependencyProperty.Register("DecodeHeight", typeof(string), typeof(MainPage), new PropertyMetadata("90"));


        public int DecodeWidthValue
        {
            get { return (int)GetValue(DecodeWidthValueProperty); }
            set { SetValue(DecodeWidthValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DecodeWidthValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DecodeWidthValueProperty =
            DependencyProperty.Register("DecodeWidthValue", typeof(int), typeof(MainPage), new PropertyMetadata(0));
        public int DecodeHeightValue
        {
            get { return (int)GetValue(DecodeHeightValueProperty); }
            set { SetValue(DecodeHeightValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DecodeHeightValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DecodeHeightValueProperty =
            DependencyProperty.Register("DecodeHeightValue", typeof(int), typeof(MainPage), new PropertyMetadata(0));


        public bool? Cache
        {
            get { return (bool?)GetValue(CacheProperty); }
            set { SetValue(CacheProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Cache.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CacheProperty =
            DependencyProperty.Register("Cache", typeof(bool?), typeof(MainPage), new PropertyMetadata(true));


        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int width;
            if (int.TryParse(DecodeWidth, out width))
            {
                DecodeWidthValue = width;
            }
            int height;
            if (int.TryParse(DecodeHeight, out height))
            {
                DecodeHeightValue = height;
            }

            if (!String.IsNullOrEmpty(ImageUrl))
            {
                ImageUri = new Uri(ImageUrl);
                Normal.Source = CreateImage();
                var scaled = CreateImage();
                scaled.DecodePixelHeight = DecodeHeightValue;
                scaled.DecodePixelWidth = DecodeWidthValue;
                Scaled.Source = scaled;
            }
        }

        private BitmapImage CreateImage()
        {
            var image = new BitmapImage();
            image.UriSource = ImageUri;
            image.CreateOptions = Cache.Value ? Windows.UI.Xaml.Media.Imaging.BitmapCreateOptions.None : Windows.UI.Xaml.Media.Imaging.BitmapCreateOptions.IgnoreImageCache;
            return image;
        }
    }
}
