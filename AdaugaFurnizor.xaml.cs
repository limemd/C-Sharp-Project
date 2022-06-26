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
    /// Interaction logic for AdaugaFurnizor.xaml
    /// </summary>
    public partial class AdaugaFurnizor : UserControl
    {
        public AdaugaFurnizor()
        {
            InitializeComponent();
            
        }

        private void Tb_cod_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
            tb_cod.MaxLength =4;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (tb_nume.Text == "")
            {
                MessageBox.Show("Introduceti valori!!!");
                return;

            }
            if (tb_adresa.Text == "")
            {
                MessageBox.Show("Introduceti valori!!!");
                return;

            }
            if (tb_cod.Text == "")
            {
                MessageBox.Show("Introduceti valori!!!");
                return;

            }
            using (AutopieseEntities db = new AutopieseEntities())
            {
                var furnizorNou = new Furnizori()
                {
                  
                    nume = tb_nume.Text,
                    adresa =  tb_adresa.Text,
                    cod_fiscal = int.Parse(tb_cod.Text)
                    

                };
                db.Furnizoris.Add(furnizorNou);
                db.SaveChanges();

            }
            MessageBox.Show("Changes Saved!");

        }
    }
}
