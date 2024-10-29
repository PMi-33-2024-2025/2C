using System.Windows;
using _2C.BusinessLogic.Services;
using _2C.BusinessLogic.ViewModels;
using _2C.DataAccess;
using _2C.DataAccess.DTO;
using _2C.DataAccess.Models;

namespace _2C
{
    public partial class LoginWindow : Window
    {
        private readonly IUserService _userService;

        public LoginWindow(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var loginDto = new LoginDto
            {
                Email = EmailTextBox.Text,
                Password = PasswordBox.Password
            };

            bool isLoggedIn = await _userService.Login(loginDto);
            if (isLoggedIn)
            {
                // Pass both ProductViewModel and UserService to MainWindow
                var productViewModel = new ProductViewModel(new ProductService(new _2CDbContext()), _userService);
                var mainWindow = new MainWindow(productViewModel, _userService);
                mainWindow.Show();

                this.Close(); // Close LoginWindow
            }
            else
            {
                MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegisterWindow(_userService);
            registerWindow.ShowDialog();
        }
    }
}
