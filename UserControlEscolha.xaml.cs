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
    /// Interação lógica para UserControlEscolha.xam
    /// </summary>
    public partial class UserControlEscolha : UserControl
    {
        public UserControlEscolha()
        {
            InitializeComponent();
           
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            produse.Children.Clear();
            produse.Children.Add(new ShowProduseGrid());
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            produse.Children.Clear();
            produse.Children.Add(new AdaugaProduseGrid());
        }
    }
}
