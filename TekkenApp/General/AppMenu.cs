using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace TekkenApp.General
{
    public class AppMenu : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public AppMenu() { }
        public AppMenu(Action<int> func)
        {
            SetDefaults = func;
        }

        private Action<int> SetDefaults { get; set; }
        private List<MenuItemObject> MenuItemObjectList { get; set; } = new List<MenuItemObject>();

        public List<MenuItem> MenuItemList { get; set; } = new List<MenuItem>();
        public UserControl ActiveUserControl { get; set; }

        public void AddMenuItem<TDataContext, TUserControl>(string header) where TUserControl : UserControl
        {
            var obj = new MenuItemObject()
            {
                DataContextObject = typeof(TDataContext),
                UserControl = typeof(TUserControl)
            };

            MenuItemObjectList.Add(obj);

            var item = new MenuItem()
            {
                Header = header,
                IsCheckable = true,
                IsEnabled = true
            };

            item.Click += new RoutedEventHandler(ClickEvent);

            Binding menuCheckBinding = new Binding("IsChecked")
            {
                Source = this,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };

            BindingOperations.SetBinding(item, MenuItem.IsCheckableProperty, menuCheckBinding);
            MenuItemList.Add(item);
        }

        private void ClickEvent(object sender, RoutedEventArgs e)
        {
            var headerName = (sender as MenuItem).Header.ToString();
            ManageCheckedItems(headerName);
        }

        private void ManageCheckedItems(string _headerName)
        {
            for (int i = 0; i < MenuItemList.Count; i++)
            {
                var item = MenuItemList[i];

                if (item.Header.ToString() == _headerName)
                {
                    if (item.IsChecked) { item.IsChecked = true; } //Previously Selected
                    else
                    {
                        item.IsChecked = true;
                        SelectIndex(i);
                    }
                }
                else { item.IsChecked = false; }
            }
        }

        public void SelectIndex(int index)
        {
            var item = MenuItemObjectList[index];

            ActiveUserControl = Activator.CreateInstance(item.UserControl, false) as UserControl;
            ActiveUserControl.DataContext = Activator.CreateInstance(item.DataContextObject);

            SetDefaults?.Invoke(index);
            MenuItemList[index].IsChecked = true;
            OnPropertyChanged("ActiveUserControl");
        }

        private class MenuItemObject
        {
            public Type UserControl { get; set; }
            public Type DataContextObject { get; set; }
        }
    }
}
