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
    /// Interaction logic for DeleteWindow.xaml
    /// </summary>
    public partial class DeleteWindow : Window
    {
        //DeleteViewModel ViewModel;
        private IDeleteViewModel ViewModel;
        public DeleteWindow(IDeleteViewModel ViewModel)
        {
            InitializeComponent();
            this.ViewModel = ViewModel;
            this.DataContext = ViewModel;
            //ViewModel = new DeleteViewModel();
            //this.DataContext = ViewModel;
        }
    }
}
