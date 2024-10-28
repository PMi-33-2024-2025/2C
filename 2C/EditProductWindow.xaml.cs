using _2C.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;

namespace _2C
{
    public partial class EditProductWindow : Window
    {
        public Product Product { get; private set; }
        public bool IsProductUpdated { get; private set; } = false;

        public EditProductWindow(Product product)
        {
            InitializeComponent();

            // Load product details into textboxes
            Product = product;
            NameTextBox.Text = Product.Name;
            PriceTextBox.Text = Product.Price.ToString();
            QuantityTextBox.Text = Product.Quantity.ToString();
            StorageIdTextBox.Text = Product.StorageId.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Update product with entered details
            Product.Name = NameTextBox.Text;
            Product.Price = double.TryParse(PriceTextBox.Text, out double price) ? price : Product.Price;
            Product.Quantity = int.TryParse(QuantityTextBox.Text, out int quantity) ? quantity : Product.Quantity;
            Product.StorageId = long.TryParse(StorageIdTextBox.Text, out long storageId) ? storageId : Product.StorageId;

            // Validate product data
            if (ValidateProduct(Product))
            {
                IsProductUpdated = true;
                DialogResult = true; // Close window and return true
            }
        }

        private bool ValidateProduct(Product product)
        {
            var validationContext = new ValidationContext(product);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(product, validationContext, validationResults, true);

            if (!isValid)
            {
                string errors = string.Join("\n", validationResults.Select(r => r.ErrorMessage));
                MessageBox.Show(errors, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return isValid;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Close without saving
        }
    }
}
