using Microsoft.Win32;
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
using System.Xml;
using Topic3_JSON_Serialization.Models;

namespace Topic3_JSON_Serialization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProductManagement productManagement = new ProductManagement();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadProducts()
        {
            lvProducts.ItemsSource = null;
            lvProducts.ItemsSource = productManagement.GetProducts();
        }
        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            lvProducts.ItemsSource = productManagement.ImportData();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newProduct = new Product
                {
                    ProductId = int.Parse(txtProductId.Text.Trim()),
                    ProductName = txtProductName.Text.Trim()
                };

                productManagement.InsertProduct(newProduct);
                MessageBox.Show("Insert success", "Information");
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert product");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var productUpdate = new Product
                {
                    ProductId = int.Parse(txtProductId.Text.Trim()),
                    ProductName = txtProductName.Text.Trim()
                };

                productManagement.UpdateProduct(productUpdate);
                MessageBox.Show("Update success", "Information");
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update product");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var productDelete = new Product
                {
                    ProductId = int.Parse(txtProductId.Text.Trim()),
                    ProductName = txtProductName.Text.Trim()
                };

                MessageBoxResult confirm = MessageBox.Show("Do you want to delete?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirm == MessageBoxResult.Yes)
                {
                    productManagement.DeleteProduct(productDelete);
                    MessageBox.Show("Delete success", "Information");
                    LoadProducts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update product");
            }
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            productManagement.ExportData();
        }
    }
}