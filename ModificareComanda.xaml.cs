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
    /// Interaction logic for ModificareComanda.xaml
    /// </summary>
    public partial class ModificareComanda : Window
    {
        public ModificareComanda(int cod)
        {
            InitializeComponent();
            using (AutopieseEntities db = new AutopieseEntities())
            {
                var prodnames = from e in db.Produses
                                select e.nume;
                cb_prodname.ItemsSource = prodnames.ToList();

            }
            using (AutopieseEntities db = new AutopieseEntities())
            {//date in combobox
                var furnames = from e in db.Furnizoris
                               select new { e.nume, e.cod_furnizor };
                foreach (var item in furnames)
                {
                    cb_furname.Items.Add(new Custom_Furnizor { nume = item.nume, id = item.cod_furnizor });
                }
                cb_furname.DisplayMemberPath = "nume";
                cb_furname.SelectedValuePath = "id";

            }

            using (AutopieseEntities db = new AutopieseEntities())
            {
                var row = from e in db.Comandas
                          where e.cod_comanda == cod
                          select new { e.cod_produs, e.cantitate, e.data_venire, e.cod_furnizor };
                foreach (var item in row)
                {
                    cb_prodname.SelectedIndex = item.cod_produs-1;
                    tb_quantity.Text = item.cantitate.ToString();
                    datecomanda.SelectedDate = item.data_venire;
                    cb_furname.SelectedValue =item.cod_furnizor ;
                    //cb_furname.SelectedIndex = item.cod_furnizor - 1;



                }
                //aici
                




            }
            cod_comanda = cod;

        }
        public int cod_comanda = new int();


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cb_furname.SelectedIndex==-1)
            {
                MessageBox.Show("Introduceti valori!!!");
                return;
            }
            if (cb_prodname.SelectedIndex == -1)
            {
                MessageBox.Show("Introduceti valori!!!");
                return;
            }
            if (tb_quantity.Text=="")
            {
                MessageBox.Show("Introduceti valori!!!");
                return;
            }

            using(AutopieseEntities db = new AutopieseEntities())
            {
                db.adauga_comanda(cb_prodname.SelectedIndex+1, int.Parse(tb_quantity.Text),datecomanda.SelectedDate,int.Parse(cb_furname.SelectedValue.ToString()) , cod_comanda);
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
