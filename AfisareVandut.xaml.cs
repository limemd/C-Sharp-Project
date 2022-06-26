using Microsoft.Win32;
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
using System.Xml;

namespace Pizzaria1
{
    /// <summary>
    /// Interaction logic for AfisareVandut.xaml
    /// </summary>
    public partial class AfisareVandut : UserControl
    {
        public AfisareVandut()
        {
            InitializeComponent();

            using (AutopieseEntities db = new AutopieseEntities())
            {
                var vindute = db.vandut_view.ToList();
                dgname.ItemsSource = vindute;
                vandutList = db.sortaredata_vandute(null, null).ToList();

            }

        }

        private List<sortaredata_vandute_Result> vandutList = new List<sortaredata_vandute_Result>();
        


        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            using (AutopieseEntities db = new AutopieseEntities())
            {
                var vindute = db.sortaredata_vandute(data1.SelectedDate, data2.SelectedDate);
                dgname.ItemsSource = vindute;
                vandutList = db.sortaredata_vandute(data1.SelectedDate, data2.SelectedDate).ToList();
            }

        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            XmlElement xmlList = doc.CreateElement("Vandute");
            doc.AppendChild(xmlList);
            foreach (var item in vandutList)
            {
                XmlElement xml0 = doc.CreateElement("Comanda");

                XmlElement xml1 = doc.CreateElement("Cod_Comanda");
                XmlText text1 = doc.CreateTextNode(item.cod_comanda.ToString());
                xml1.AppendChild(text1);

                XmlElement xml2 = doc.CreateElement("Nume_Produs");
                XmlText text2 = doc.CreateTextNode(item.nume.ToString());
                xml2.AppendChild(text2);

                XmlElement xml3 = doc.CreateElement("Cantitate");
                XmlText text3 = doc.CreateTextNode(item.cantitate.ToString());
                xml3.AppendChild(text3);

                XmlElement xml4 = doc.CreateElement("Data_Efectuarii");
                XmlText text4 = doc.CreateTextNode(item.data_venire.ToString());
                xml4.AppendChild(text4);


                xml0.AppendChild(xml1);
                xml0.AppendChild(xml2);
                xml0.AppendChild(xml3);
                xml0.AppendChild(xml4);
                xmlList.AppendChild(xml0);
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "XML-File | *.xml"
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                doc.Save(saveFileDialog.FileName);
            }
        }
    }
}
