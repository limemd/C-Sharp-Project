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
    /// Interaction logic for Comanda.xaml
    /// </summary>
    public partial class Comanda : UserControl
    {
        public Comanda()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            comanda.Children.Clear();
            comanda.Children.Add(new AfisareComandaGrid());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            comanda.Children.Clear();
            comanda.Children.Add(new AdaugaComandaGrid());
        }
    }
}
