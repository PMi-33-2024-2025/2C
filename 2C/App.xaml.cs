using System.Windows;
using _2C.BusinessLogic.Services;
using _2C.DataAccess;

namespace _2C
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var context = new _2CDbContext(); // Initialize DbContext
            var userService = new UserService(context); // Initialize UserService

            var loginWindow = new LoginWindow(userService);
            loginWindow.Show();
        }
    }
}
