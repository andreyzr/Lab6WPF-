using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace Lab6WPF_Свойства_зависимостей_и_маршрутизация_событий_
{
    internal class Person:DependencyObject
    {
        public static readonly DependencyProperty AgeProperty;
        private string name;
        public string Name 
        {
            get => name;
            set => name=value;
        }
        public int Age
        {
            get => (int)GetValue(AgeProperty);
            set => SetValue(AgeProperty,value);
        }
        public Person(string name, int age)
        {
            this. Name = name;
            this.Age = age;
        }
        static Person()
        {
            AgeProperty = DependencyProperty.Register(
                nameof(Age),
                typeof(int),
                typeof(Person),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceAge)),
                new ValidateValueCallback(ValidateAge));
        }

        private static bool ValidateAge(object value)
        {
            int v = (int)value;
            if (v >= 0 && v < 200)
                return true;
            else
                return false;
        }

        private static object CoerceAge(DependencyObject d, object baseValue)
        {
            int v=(int)baseValue;
            if (v >= 0 )
                return v;
            else
                return 0;
        }

        public string Print()
        {
            return $"{Name} {Age}";
        }
    }
}
