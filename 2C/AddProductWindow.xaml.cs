using _2C.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;

namespace _2C
{
    public partial class AddProductWindow : Window
    {
        public string ProductName => NameTextBox.Text;
        public double ProductPrice => double.TryParse(PriceTextBox.Text, out double price) ? price : 0;
        public int ProductQuantity => int.TryParse(QuantityTextBox.Text, out int quantity) ? quantity : 0;
        public long ProductStorageId => long.TryParse(StorageIdTextBox.Text, out long storageId) ? storageId : 0;

        public bool IsProductAdded { get; private set; } = false;

        public AddProductWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new Product instance with entered data
            var newProduct = new Product
            {
                Name = ProductName,
                Price = ProductPrice,
                Quantity = ProductQuantity,
                StorageId = ProductStorageId
            };

            // Validate the new product
            if (ValidateInput(newProduct))
            {
                IsProductAdded = true;
                DialogResult = true; // Close the window and return true
            }
        }

        private bool ValidateInput(Product product)
        {
            var validationContext = new ValidationContext(product);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(product, validationContext, validationResults, true);

            // If invalid, display errors on the UI
            if (!isValid)
            {
                string errors = string.Join("\n", validationResults.Select(r => r.ErrorMessage));
                MessageBox.Show(errors, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return isValid;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Close the window without adding
        }
    }
}
