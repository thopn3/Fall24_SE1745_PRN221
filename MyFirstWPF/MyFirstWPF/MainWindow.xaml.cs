using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyFirstWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frmMain.Content = new Page1();
        }

        private void btnPage1_Click(object sender, RoutedEventArgs e)
        {
            frmMain.Content = new Page1();
        }

        private void btnPage2_Click(object sender, RoutedEventArgs e)
        {
            frmMain.Content = new Page2();
        }
    }
}