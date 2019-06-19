using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TekkenApp.General
{
    public class ExtraParameterRoutedEventArgs : RoutedEventArgs
    {
        public int MenuId { get; }

        public ExtraParameterRoutedEventArgs(RoutedEvent routedEvent, int _menuId) : base(routedEvent)
        {
            this.MenuId = _menuId;
        }
    }
}
