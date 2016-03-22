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
        private AdamBoard1 board1 = new AdamBoard1();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            AdamBoard2 board = new AdamBoard2();

        }

        private void btnOn_Click(object sender, RoutedEventArgs e)
        {
            board1.TurnOnLamp();
        }

        private void btnStatus_Click(object sender, RoutedEventArgs e)
        {
            String status = (board1.StatusLamp()) ? "Aan" : "Uit";
            MessageBox.Show("De Lamp staat " + status, "Status Lamp");
        }

        private void btnOff_Click(object sender, RoutedEventArgs e)
        {
            board1.TurnOffLamp();
        }

        private void btnOn_Copy_Click(object sender, RoutedEventArgs e)
        {
            board1.TurnOnVentilator();
        }

        private void btnStatus_Copy_Click(object sender, RoutedEventArgs e)
        {
            String status = (board1.StatusVentilator()) ? "Aan" : "Uit";
            MessageBox.Show("De Ventilator staat " + status, "Status Lamp");
        }

        private void btnOff_Copy_Click(object sender, RoutedEventArgs e)
        {
            board1.TurnOffVentilator();
        }
    }
}
