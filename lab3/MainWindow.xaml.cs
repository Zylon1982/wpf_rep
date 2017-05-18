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
            lwSelection.Items.Clear();
            
            foreach (Auto ap in repository.GetAll())
            {
                lwSelection.Items.Add(ap);
                
                lstAuto.Add(ap);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd b = new WindowAdd();
            b.ShowDialog();
            lwSelection.Items.Clear();
            foreach (Auto ap in repository.GetAll())
            {
                lwSelection.Items.Add(ap);
                lstAuto.Add(ap);
            }
        }

        private void DelModel_Click(object sender, RoutedEventArgs e)
        {
            foreach (Auto ap in repository.GetAll())
            {
                if (ap.Model == tbSearch.Text)
                {
                    //MessageBox.Show("Вы уверены?", "Удаление авто из базы",
                    //         MessageBoxButton.OKCancel, MessageBoxImage.Question);
                   // if (DialogResult.Value == MessageBoxResult.OK)
                    {
                        //listBox1.Items.Remove(ap);
                        //lstAuto.Remove(ap);
                        repository.Remove((string)ap.Model);
                    }
                }
            }

            lwSelection.Items.Clear();
            foreach (Auto ap in repository.GetAll())
            {
                lwSelection.Items.Add(ap);
                lstAuto.Add(ap);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e) // как сделать поиск из DAL_Mock???
        {
            lwSelection.Items.Clear();
            
            foreach (Auto ap in repository.GetAll())
            {
                if (cmbModel.IsSelected)
                {
                    if (tbSearch.Text == ap.Model)
                    {
                        lwSelection.Items.Add(ap);
                        lstAuto.Add(ap);
                    }
                }

                if(cmbName.IsSelected)
                {
                    if (tbSearch.Text == ap.Name)
                    {
                        lwSelection.Items.Add(ap);
                        lstAuto.Add(ap);
                    }
                }
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            lwSelection.Items.Clear();
            foreach (Auto ap in repository.GetAll())
            {
                lwSelection.Items.Add(ap);
                lstAuto.Add(ap);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.Auto auto = lwSelection.SelectedItem as Auto;
            if (auto != null)
            {
                labelPrice.Content = auto.Price.ToString();
                labelModelName.Content = auto.Model.ToString();
                labelMaxSpeed.Content = auto.MaxSpeed.ToString();
                labelFuelConsuption.Content = auto.FuelConsuption.ToString();
                labelColor.Content = auto.Color.ToString();
                if (cmbModel.IsSelected)
                {
                    tbSearch.Text = auto.Model.ToString();
                }
                if(cmbName.IsSelected)
                {
                    tbSearch.Text = auto.Name.ToString();
                }
            }
        }
    }
}
