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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace ImagePerf
{
    public sealed partial class LabelInput : UserControl
    {
        public string Label { get { return (string)GetValue(LabelProperty); } set { SetValue(LabelProperty, value); } }
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(nameof(Label), typeof(string), typeof(LabelInput), new PropertyMetadata(DependencyProperty.UnsetValue));
        public string Value { get { return (string)GetValue(ValueProperty); } set { SetValue(ValueProperty, value); }  }
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(string), typeof(LabelInput), new PropertyMetadata(DependencyProperty.UnsetValue));

        public LabelInput()
        {
            this.InitializeComponent();
        }
    }
}
