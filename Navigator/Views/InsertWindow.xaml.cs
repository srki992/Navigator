using Navigator.ViewModels;
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

namespace Navigator.Views
{
    /// <summary>
    /// Interaction logic for InsertWindow.xaml
    /// </summary>
    public partial class InsertWindow : Window
    {
        //InsertViewModel ViewModel;
        private IInsertViewModel insertViewModel;
        public InsertWindow(IInsertViewModel insertViewModel)
        {
            InitializeComponent();
            this.insertViewModel = insertViewModel;
            this.DataContext = insertViewModel;
            //ViewModel = new InsertViewModel();
            //this.DataContext = ViewModel;
        }
    }
}
