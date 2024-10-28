using _2C.BusinessLogic.Services;
using _2C.DataAccess.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _2C.BusinessLogic.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        private readonly IProductService _productService;

        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                if (_selectedProduct != value)
                {
                    _selectedProduct = value;
                    OnPropertyChanged(nameof(SelectedProduct));
                }
            }
        }

        // Constructor
        public ProductViewModel(IProductService productService)
        {
            _productService = productService;
        }

        // Methods to interact with ProductService
        public async Task LoadProducts()
        {
            var products = await _productService.GetAll();
            Products.Clear();
            foreach (var product in products)
                Products.Add(product);
        }

        public async Task AddProduct(Product product)
        {
            await _productService.Create(product);
            await LoadProducts();
        }

        public async Task UpdateProduct()
        {
            if (_selectedProduct != null)
            {
                await _productService.Update(_selectedProduct.Id, _selectedProduct.Name, _selectedProduct.Price, _selectedProduct.Quantity, _selectedProduct.StorageId);
                await LoadProducts();
            }
        }

        public async Task DeleteProduct()
        {
            if (_selectedProduct != null)
            {
                //await _productService.Delete(_selectedProduct.Id);
                await LoadProducts();
            }
        }

        // INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
