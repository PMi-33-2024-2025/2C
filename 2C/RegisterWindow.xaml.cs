using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;
using _2C.DataAccess.Models;
using _2C.BusinessLogic.Services;

namespace _2C
{
    public partial class RegisterWindow : Window
    {
        private readonly IUserService _userService;

        public RegisterWindow(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var newUser = new User
            {
                Name = NameTextBox.Text,
                LastName = LastNameTextBox.Text,
                Email = EmailTextBox.Text,
                Password = PasswordBox.Password,
                StorageId = 1, // Assuming a default StorageId; adjust based on your requirements
                RoleId = 1     // Assuming a default RoleId for regular users
            };

            // Validate user data
            var validationContext = new ValidationContext(newUser);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(newUser, validationContext, validationResults, true);

            if (!isValid)
            {
                string errors = string.Join("\n", validationResults.Select(vr => vr.ErrorMessage));
                MessageBox.Show(errors, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Call Register method in UserService
            bool isRegistered = await _userService.Register(newUser);
            if (isRegistered)
            {
                MessageBox.Show("Registration successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close(); // Close the registration window
            }
            else
            {
                MessageBox.Show("User already exists or registration failed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
