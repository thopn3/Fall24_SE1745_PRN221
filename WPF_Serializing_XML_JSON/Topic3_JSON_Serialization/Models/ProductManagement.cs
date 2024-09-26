using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Windows;
using System.Xml;

namespace Topic3_JSON_Serialization.Models
{
    class ProductManagement
    {
        List<Product> products = new List<Product>();

        public List<Product> GetProducts()
        {
            return products;
        }

        public List<Product> ImportData()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog.Title = "Select file JSON to import";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    // Đọc nội dung file JSON
                    string json = File.ReadAllText(openFileDialog.FileName);

                    // Deserialize dữ liệu vào List<Product>
                    products = JsonSerializer.Deserialize<List<Product>>(json);
                    
                    MessageBox.Show("Import success!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (JsonException ex)
                {
                    MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"An error occurred while importing: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            return products;
        }

        public void InsertProduct(Product product)
        {
            try
            {
                Product p = products.SingleOrDefault(p => p.ProductId == product.ProductId);
                if (p!=null)
                {
                    throw new Exception("This product already exists");
                }
                products.Add(product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                Product p = products.SingleOrDefault(p => p.ProductId == product.ProductId);
                if (p==null)
                {
                    throw new Exception("This product did not exist");
                }
                else
                {
                    p.ProductName = product.ProductName;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteProduct(Product product)
        {
            try
            {
                Product p = products.SingleOrDefault(p => p.ProductId == product.ProductId);
                if (p == null)
                {
                    throw new Exception("This product did not exist");
                }
                else
                {
                    products.Remove(p);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ExportData()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                Title = "Save a JSON File"
            };

            if (saveFileDialog.ShowDialog() == true) // Nếu người dùng nhấn "Export data"
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    // Chuyển đổi danh sách sản phẩm sang định dạng JSON
                    string json = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true});

                    // Ghi chuỗi JSON vào file
                    File.WriteAllText(filePath, json);

                    MessageBox.Show("Export successful!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while exporting: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
