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
using System.Data;

namespace Pizzaria1
{
    /// <summary>
    /// Interaction logic for ShowProduseGrid.xaml
    /// </summary>
    public partial class ShowProduseGrid : UserControl
    {
        public ShowProduseGrid()
        {
            InitializeComponent();

            using (AutopieseEntities db = new AutopieseEntities())
            {
                var produse = db.produse_view.ToList();
                dgname.ItemsSource = produse;
            }
            using (AutopieseEntities db = new AutopieseEntities())
            {
                var categorii = from e in db.Categories
                                select e.denumire;
                cat_prod.ItemsSource = categorii.ToList();

            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Dgname_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
          
           
        }

        private void Dgname_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            produse_view produs = (produse_view)dgname.SelectedItem;

            Modificare_Produs modificare = new Modificare_Produs(produs.cod_produs);
            modificare.ShowDialog();
        }

        private void Invizibil_Click(object sender, RoutedEventArgs e)
        {
            int? id = null;
            if (cat_prod.SelectedIndex != -1)
            {
                id = cat_prod.SelectedIndex;
            }
            using (AutopieseEntities db = new AutopieseEntities())
            {

                List<pretMediu_Result> lista = db.pretMediu(id + 1).ToList();

                double rezultat = 0;

                foreach (var item in lista)
                {
                    rezultat += item.pret;
                }
                rezultat /= lista.Count();
                MessageBox.Show("Pretul mediu este  : " + rezultat.ToString() + " lei");
            }
        }

        private void Cat_prod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            invizibil.Visibility = Visibility.Visible;
        }
    }
}
