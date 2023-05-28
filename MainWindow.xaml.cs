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

namespace MVVMENTITY
{
    public partial class View : Window
    {
        //ViewModel viewModel;
        Window1 window;
        public static bool OpenWin2 = false;
        public View()
        {
            DataContext = new ViewModel();
            OpenWin2 = true;
            InitializeComponent();
            if (Window1.OpenWin1 ==false )
            {
                Window1 window1 = new Window1();
                window1.Show();
            }

        }
    }
}

