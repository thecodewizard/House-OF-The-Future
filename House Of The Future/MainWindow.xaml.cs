using House_Of_The_Future.Shared.DAL;
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

namespace House_Of_The_Future
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            new AdamBoard2().OpenConnetion2();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            AdamBoard1 board1 = new AdamBoard1();
            board1.TurnOnLamp();
        }
    }
}
