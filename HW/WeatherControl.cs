using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HW
{
     enum Precipitation
    {
        sunny,
        cliudy,
        rain,
        snow
    };
    internal class WeatherControl : DependencyObject
    {
        private Precipitation precipitation;
        public static readonly DependencyProperty TempProperty;
        private string wind_dir;
        private int wind_speed;

        public string WindDir
        {
            get => wind_dir;
            set => wind_dir = value;
        }        
        public int WindSpeed
        {
            get => wind_speed;
            set => wind_speed = value;
        }

        public WeatherControl(string wind_dir, int wind_speed, Precipitation precipitation)
        {
            this.WindDir = wind_dir;
            this.WindSpeed = wind_speed;
            this.precipitation = precipitation;
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
