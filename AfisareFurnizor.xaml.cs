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
    /// Interaction logic for AfisareFurnizor.xaml
    /// </summary>
    public partial class AfisareFurnizor : UserControl
    {
        public AfisareFurnizor()
        {
            InitializeComponent();
            using (AutopieseEntities db = new AutopieseEntities())
            {
                var furn = db.furnizor_view.ToList();
                dgname.ItemsSource = furn;
            }
        }
        
    }
}
