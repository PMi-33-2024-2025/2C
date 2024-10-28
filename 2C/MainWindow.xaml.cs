using _2C.BusinessLogic.Services;
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
            InitializeComponent();
            _productViewModel = new ProductViewModel(new ProductService(new _2CDbContext())); // Instantiate ProductService or use Dependency Injection
            DataContext = _productViewModel;
        }

        // Constructor with dependency injection for ProductViewModel
        public MainWindow(ProductViewModel productViewModel)
        {
            InitializeComponent();
            _productViewModel = productViewModel;
            DataContext = _productViewModel;
        }

        private async void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            //// Code to add a new product
            //var newProduct = new Product { /* Initialize with properties */ };
            //await _productViewModel.AddProduct(newProduct);
        }

        private async void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            // Code to edit the selected product
            if (_productViewModel.SelectedProduct != null)
            {
                await _productViewModel.UpdateProduct();
            }
        }

        private async void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            // Code to delete the selected product
            if (_productViewModel.SelectedProduct != null)
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
