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
using System.Windows.Shapes;

namespace Pizzaria1
{
    /// <summary>
    /// Interaction logic for Modificare_Produs.xaml
    /// </summary>
    public partial class Modificare_Produs : Window
    {

        public Modificare_Produs(int cod)
        {
            InitializeComponent();


            using (AutopieseEntities db = new AutopieseEntities())
            {
                var categorii = from e in db.Categories
                                select e.denumire;
                cb_categorie.ItemsSource = categorii.ToList();

            }
            using (AutopieseEntities db = new AutopieseEntities())
            {
                var row = from e in db.Produses
                          where e.cod_produs == cod
                          select new { e.nume,e.pret,e.depozit, e.cod_categorie };
                foreach (var item in row)
                {
                    tb_nume.Text = item.nume;
                    tb_pret.Text = item.pret.ToString();
                    cb_categorie.SelectedIndex = item.cod_categorie-1;

                    if (item.depozit == "da")
                    {
                        cb_depozit.SelectedIndex = 0;
                    }
                    else
                    {

                        cb_depozit.SelectedIndex = 1;
                    }

                }
                
            }
            cod_produs = cod;
        }


        public int cod_produs = new int();
        
      

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
            if (cb_depozit.SelectedIndex == -1)
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
                db.edit_produse(cod_produs, tb_nume.Text, float.Parse(tb_pret.Text), cb_categorie.SelectedIndex + 1, cb_depozit.Text);
            }
            MessageBox.Show("Changes Saved!");
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            { DragMove(); }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
