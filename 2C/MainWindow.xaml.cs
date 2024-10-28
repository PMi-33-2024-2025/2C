﻿using _2C.BusinessLogic.Services;
using _2C.BusinessLogic.ViewModels;
using _2C.DataAccess;
using _2C.DataAccess.Models;
using System.Windows;

namespace _2C
{
    public partial class MainWindow : Window
    {
        private readonly ProductViewModel _productViewModel;

        // Parameterless constructor required by WPF
        public MainWindow()
        {
            _productViewModel = new ProductViewModel(new ProductService(new _2CDbContext())); // Instantiate ProductService or use Dependency Injection
            DataContext = _productViewModel;
            InitializeComponent();
        }

        // Constructor with dependency injection for ProductViewModel
        public MainWindow(ProductViewModel productViewModel)
        {
            _productViewModel = productViewModel;
            DataContext = _productViewModel;
            InitializeComponent();
        }
        protected override async void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            await _productViewModel.LoadProducts(); // Load data as soon as the window is initialized
        }



        private async void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            var addProductWindow = new AddProductWindow();
            bool? result = addProductWindow.ShowDialog();

            if (result == true && addProductWindow.IsProductAdded)
            {
                // Create a new product with the entered data
                var newProduct = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = addProductWindow.ProductName,
                    Price = addProductWindow.ProductPrice,
                    Quantity = addProductWindow.ProductQuantity,
                    StorageId = addProductWindow.ProductStorageId
                };

                // Add the new product using the ViewModel's method
                await _productViewModel.AddProduct(newProduct);
            }
        }

        private async void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (_productViewModel.SelectedProduct == null)
            {
                MessageBox.Show("Please select a product to edit.", "Edit Product", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // Create a new EditProductWindow with the selected product
            var editProductWindow = new EditProductWindow(_productViewModel.SelectedProduct);
            bool? result = editProductWindow.ShowDialog();

            if (result == true && editProductWindow.IsProductUpdated)
            {
                // Call the UpdateProduct method in the ViewModel to save changes to the database
                await _productViewModel.UpdateProduct();
            }
        }

        private async void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (_productViewModel.SelectedProduct == null)
            {
                MessageBox.Show("Please select a product to delete.", "Delete Product", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to delete '{_productViewModel.SelectedProduct.Name}'?",
                                         "Delete Confirmation",
                                         MessageBoxButton.YesNo,
                                         MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                await _productViewModel.DeleteProduct();
            }
        }

        private async void RefreshProducts_Click(object sender, RoutedEventArgs e)
        {
            // Refresh the product list
            await _productViewModel.LoadProducts();
        }        

    }
}
