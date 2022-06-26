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

namespace Pizzaria1
{
    /// <summary>
    /// Interaction logic for UserControlFurnizor.xaml
    /// </summary>
    public partial class UserControlFurnizor : UserControl
    {
        public UserControlFurnizor()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            furnizor.Children.Clear();
            furnizor.Children.Add(new AfisareFurnizor());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            furnizor.Children.Clear();
            furnizor.Children.Add(new AdaugaFurnizor());
        }
    }
}
