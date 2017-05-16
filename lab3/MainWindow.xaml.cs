using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab3
{
    using Model;
    using Repository;
    using DAL_Mock;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        IAutoRepository repository = new AutoRepository();
        private static List<Auto> lstAuto = new List<Auto>();
        public MainWindow()
        {
            InitializeComponent();
            listBox1.Items.Clear();
            foreach (Auto ap in repository.GetAll())
            {
                listBox1.Items.Add(ap);
                lstAuto.Add(ap);
            }
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.Auto auto = listBox1.SelectedItem as Auto;
            if (auto != null)
            {
                labelPrice.Content = auto.Price.ToString();
                labelModelName.Content = auto.ModelName.ToString();
                labelMaxSpeed.Content = auto.MaxSpeed.ToString();
                labelFuelConsuption.Content = auto.FuelConsuption.ToString();
                labelColor.Content = auto.Color.ToString();
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd b = new WindowAdd();
            b.ShowDialog();
            listBox1.Items.Clear();
            foreach (Auto ap in repository.GetAll())
            {
                listBox1.Items.Add(ap);
                lstAuto.Add(ap);
            }
        }

        private void DelModel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы уверены?", "Удаление авто из базы",
                     MessageBoxButton.OKCancel , MessageBoxImage.Question);
        }
    }
}
