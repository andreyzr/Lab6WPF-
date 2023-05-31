using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HW
{
    internal class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TempProperty;
        private string windDir;
        private int precipitation;
        public string WindDir
        {
            get => windDir;
            set => windDir=value;
        }
        public int Precipitation
        {
            get => precipitation;
            set => precipitation = value;
        }
        public WeatherControl(string windDir, int precipitation, int tempProperty)
        {
            this.WindDir = windDir;
            this.Precipitation = precipitation;
            this.TempProperty = tempProperty;
        }
        public int Temp
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }
        static WeatherControl()
        {
            TempProperty = DependencyProperty.Register(
                nameof(Age),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.AffectsArrange |
                FrameworkPropertyMetadataOptions.AffectsRender,
                null,
                new CoerceValueCallback(CoerceTemp)),
                new ValidateValueCallback(ValidateTemp));
        }

    }
}
