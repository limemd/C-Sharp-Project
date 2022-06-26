using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AdaugaComandaGrid.xaml
    /// </summary>
    public partial class AdaugaComandaGrid : UserControl
    {
        public AdaugaComandaGrid()
        {
            InitializeComponent();
            using (AutopieseEntities db = new AutopieseEntities())
            {
                var prodnames = from e in db.Produses
                                select e.nume;
                cb_prodname.ItemsSource = prodnames.ToList();

            }
            using (AutopieseEntities db = new AutopieseEntities())
            {
                var furnames = from e in db.Furnizoris
                               select e.nume;
                cb_furname.ItemsSource = furnames.ToList();

            }
        }

        private void Tb_quantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cb_furname.SelectedIndex == -1)
            {
                MessageBox.Show("Introduceti valori!!!");
                return;
            }
            if (cb_prodname.SelectedIndex == -1)
            {
                MessageBox.Show("Introduceti valori!!!");
                return;
            }
            if (tb_quantity.Text == "")
            {
                MessageBox.Show("Introduceti valori!!!");
                return;
            }
            using (AutopieseEntities db = new AutopieseEntities())
            {
                var comanda = new Comanda()
                {
                     cod_produs = cb_prodname.SelectedIndex+1,
                     cantitate  = int.Parse(tb_quantity.Text),
                     data_venire = datecomanda.SelectedDate.Value,
                     cod_furnizor = cb_furname.SelectedIndex+1
                };
                db.Comandas.Add(comanda);
                db.SaveChanges();

            }
            MessageBox.Show("Changes Saved!");
        }
    }
}
