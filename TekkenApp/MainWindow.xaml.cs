using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TekkenApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //Exception Handler
            AppDomain appDomain = AppDomain.CurrentDomain;
            appDomain.UnhandledException += new UnhandledExceptionEventHandler(ExceptionHandler);

            MainModel = new TekkenApplicationModel();

            this.DataContext = MainModel;


            //Initializes Application
            InitializeComponent();
        }

        public TekkenApplicationModel MainModel { get; set; }

        private void ExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;

            MessageBox.Show(e.ToString());

            //int ExceptionId = SendExceptionToDb(e);

            //if (ExceptionId == -2) { return; } //Means Error in dbsave or connection
            //else if (ExceptionId < 0) { MessageBox.Show($"Exception Id: {ExceptionId}\n{e.Message}"); }

            //Properties.Settings.Default.ClosedByException = true;
            //Properties.Settings.Default.Save();
            //System.Windows.Forms.Application.Restart();
            //Process.GetCurrentProcess().Kill();
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }
    }

}
