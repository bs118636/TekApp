using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using TekkenApp.DataContexts;
using TekkenApp.General;
using TekkenApp.UserControls;

namespace TekkenApp
{
    public class TekkenApplicationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public TekkenApplicationModel()
        {
            //OptionsMenu = GetOptionsMenu();
            //OnPropertyChanged("OptionsMenu");

            void function(int x) => Properties.Settings.Default.LastMenu = x;

            this.MenuHandler = new AppMenu(function);
            MenuHandler.AddMenuItem<MoveListDataContext, MoveList>("Character Move List");
            MenuHandler.AddMenuItem<MoveSearchDataContext, MoveSearch>("Move Search");

            MenuHandler.SelectIndex(0);
        }

        public AppMenu MenuHandler { get; set; }

        public List<MenuItem> OptionsMenu
        {
            get
            {
                var menu = new List<MenuItem>();

                //Universal
                var menuItem = new MenuItem()
                {
                    IsCheckable = false,
                    IsEnabled = true
                };
                menuItem.Click += new RoutedEventHandler(FirstMenuClickHandler);

                //Exit
                menuItem.Header = "Exit";
                menuItem.Tag = 1;
                menu.Add(menuItem);


                //menuItem.Click += (s, args) =>
                //{
                //    FirstMenuClickHandler(s, args, 1);
                //    //new RoutedEventHandler(this.FirstMenuClickHandler);
                //};
                //menuItem.Click += new ExtraParameterRoutedEventArgs(this.FirstMenuClickHandler, 1);

                //var settingsMenuItems = new MenuItem()
                //{
                //    Header = "Settings"
                //};

                //menu.Add(settingsMenuItems);

                return menu;
            }
        }

        public void FirstMenuHandler(int x) { }

        private void FirstMenuClickHandler(object sender, RoutedEventArgs e)
        {
            var item = (MenuItem)sender;
            int menu = (int)item.Tag;

            if (menu == 1) //Exit
            {
                System.Environment.Exit(0);
            }
            else { MessageBox.Show("Error"); }
        }

        public string WindowTitle { get; set; } = "Tekken App";
    }
}