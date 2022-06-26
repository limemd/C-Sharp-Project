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
    /// Interaction logic for AdaugaProduseGrid.xaml
    /// </summary>
    public partial class AdaugaProduseGrid : UserControl
    {
        public AdaugaProduseGrid()
        {
            InitializeComponent();
            using (AutopieseEntities db = new AutopieseEntities())  
            {
                var categorii = from e in db.Categories
                                select e.denumire;
                cb_categorie.ItemsSource = categorii.ToList();
               
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            if (tb_nume.Text == "")
            {
                MessageBox.Show("Introduceti valori!!!");
                return;

            }
            if (tb_pret.Text == "")
            {
                MessageBox.Show("Introduceti valori!!!");
                return;

            }
            if (cb_depozit.SelectedIndex==-1)
            {
                MessageBox.Show("Selectati valoarea!!!");
                return;

            }
            if (cb_categorie.SelectedIndex == -1)
            {
                MessageBox.Show("Selectati valoarea!!!");
                return;

            }

            using (AutopieseEntities db = new AutopieseEntities())
            {
                var produs = new Produse()
                {
                    nume = tb_nume.Text,
                    pret = float.Parse(tb_pret.Text),
                    cod_categorie = cb_categorie.SelectedIndex + 1,
                    depozit = cb_depozit.Text.ToLower()

                };
                db.Produses.Add(produs);
                db.SaveChanges();

            }
            MessageBox.Show("Changes Saved!");

        }
    }
}
