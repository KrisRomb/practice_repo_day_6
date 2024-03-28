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

namespace Ткани
{
    /// <summary>
    /// Логика взаимодействия для ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        public ProductWindow()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWndw = new MainWindow();
            mainWndw.Show();
            this.Close();
        }
        TradeEntities entity = new TradeEntities();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            productsDG.ItemsSource = entity.Product.ToList();
        }
    }
}
