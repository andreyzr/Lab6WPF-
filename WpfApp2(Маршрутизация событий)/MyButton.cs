using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp2_Маршрутизация_событий_
{
    public class MyButton : Button
    {
        public static RoutedEvent MyButtonClickEvent;
        static MyButton()
        {
            MyButtonClickEvent = EventManager.RegisterRoutedEvent("MyButtonClickEvent",
                RoutingStrategy.Tunnel,
                typeof(RoutedEventHandler),
                typeof(MyButton));
        }
        public event RoutedEventHandler MyButtonClick
        {
            add { AddHandler(MyButtonClickEvent, value); }
            remove { RemoveHandler(MyButtonClickEvent, value); }
        }
        protected override void OnClick()
        {
            base.OnClick();
            //Аргумент который будет передан обработчику событий.
            RoutedEventArgs args = new RoutedEventArgs(MyButton.MyButtonClickEvent,this);
            //Вызов события.Событие, которое должно быть вызвано, определяется по параметрам объекта типа  RoutedEventArgs
            RaiseEvent(args);
        }
    }
}
