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
        public View()
        {
            Window1 bWin = new Window1();
            bWin.Show();
            //InitializeComponent();
            DataContext = new ViewModel();
            InitializeComponent();

            //bWin.Owner = this;
            //bWin.Show();
        }
    }
}

