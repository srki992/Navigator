using Microsoft.Win32;
using Navigator.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Navigator.Views
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        //KandidatiViewModel ViewModel;
        private IKandidatiViewModel kandidatiViewModel;
        public HomeWindow(IKandidatiViewModel kandidatiViewModel)
        {
            InitializeComponent();
            this.kandidatiViewModel = kandidatiViewModel;
            this.DataContext = kandidatiViewModel;
            //ViewModel = new KandidatiViewModel();
            //this.DataContext = ViewModel;
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dgKandidati.SelectAllCells();
                dgKandidati.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, dgKandidati);
                String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
                String result = (string)Clipboard.GetData(DataFormats.Text);
                dgKandidati.UnselectAllCells();
                System.IO.Directory.CreateDirectory(@"C:\excel");
                string trenutniTrenutak = DateTime.UtcNow.ToString("yyyyMMddHHmmss").ToString();
                System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"C:\excel\test"+ trenutniTrenutak +".xls");
                file1.WriteLine(result.Replace(',', ' '));
                file1.Close();

                MessageBox.Show("Uspešno je izvršen еxport fajla na putanji C:\\excel\\test"+ trenutniTrenutak + ".xls.");

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //excel.Quit();
                //workbook = null;
                //excel = null;

            }
        }
    }
}
