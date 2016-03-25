using House_Of_The_Future.Shared.DAL;
using System;
using System.Windows;

namespace House_Of_The_Future
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AdamBoard1 board1;

        public MainWindow()
        {
            InitializeComponent();
            board1 = new AdamBoard1();
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

        private void btnStatusses_Click(object sender, RoutedEventArgs e)
        {
            String text = "";
            text += "pot1: " + board1.StatusPotentiometer1().ToString() + Environment.NewLine;
            //foreach(bool b in board1.AllStatuses())
            //{
            //    text += (b) ? "true" : "false" + Environment.NewLine;
            //}

            MessageBox.Show("The inputs are:" + Environment.NewLine + text, "Input Statusses", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
