﻿using System;
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
using System.Windows.Shapes;

namespace MVVMENTITY
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public static bool OpenWin1 = false;
        public Window1()
        {
            DataContext = new ViewModel();
            InitializeComponent();
            OpenWin1 = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if (View.OpenWin2 == false)
            //{
               View view = new View();
               view.Show();
            //}
        }
    }
}
