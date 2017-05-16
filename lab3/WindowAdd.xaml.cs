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
using System.Windows.Shapes;
using System.IO;

namespace lab3
{
    using Model;
    using Repository;
    using DAL_Mock;
    /// <summary>
    /// Interaction logic for WindowAdd.xaml
    /// </summary>
    public partial class WindowAdd : Window
    {
        IAutoRepository repository = new AutoRepository();
        public WindowAdd()
        {
            InitializeComponent();
        }

        public void TextBoxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
                
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            string Color = tbColor.Text; // инициализация переменной ModelName считанным словом
            string ModelName = tbName.Text;
            int MaxSpeed = Convert.ToInt32(tbMS.Text); // инициализация переменной MaxCargo считанным словом
            int Price = Convert.ToInt32(tbP.Text); // инициализация переменной Passangers считанным словом
            double FuelConsuption = Convert.ToDouble(tbFC.Text); // инициализация переменной FuelLoad считанным словом
            Auto infAuto = new Auto(ModelName, Color, MaxSpeed, Price, FuelConsuption);

            repository.Add(infAuto);
            
            Close();
        }
            private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
