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
            set => windDir = value;
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
        }
        public int Temp
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }
        static WeatherControl()
        {
            TempProperty = DependencyProperty.Register(
                nameof(Temp),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.AffectsArrange |
                FrameworkPropertyMetadataOptions.AffectsRender,
                null,
                new CoerceValueCallback(CoerceTemp)),
                new ValidateValueCallback(ValidateTemp));
        }
        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50)
                return v;
            else
                return 0;
        }
        private static bool ValidateTemp(object value)
        {
            int v = (int)value;
            if (v >= -50 && v < 50)
                return true;
            else
                return false;
        }

    }
}
