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
    /// Interaction logic for AfisareComandaGrid.xaml
    /// </summary>
    public partial class AfisareComandaGrid : UserControl
    {
        public AfisareComandaGrid()
        {
            InitializeComponent();

            using (AutopieseEntities db = new AutopieseEntities())
            {
                var comenzi = db.comanda_view.ToList();
                dgname.ItemsSource = comenzi;
            }
        }

        private void Dgname_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comanda_view comanda = (comanda_view)dgname.SelectedItem;

            ModificareComanda updatecomanda = new ModificareComanda(comanda.cod_comanda);
            updatecomanda.ShowDialog();
        }
    }
}
