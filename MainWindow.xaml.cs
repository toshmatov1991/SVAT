using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Soliders
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }




        //Метод хэширования вводимого пароля
        private string GH(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }

        private void openWin_Click(object sender, RoutedEventArgs e)
        {
            //При нажатии на кнопку Войти
            if(string.IsNullOrEmpty(polzovatel.Text) && string.IsNullOrEmpty(password_user.Password)
                || string.IsNullOrEmpty(polzovatel.Text) || string.IsNullOrEmpty(password_user.Password))
            {
                MessageBox.Show("Вы пропустили одно или несколько полей", "Внимательно!", MessageBoxButton.OK, MessageBoxImage.None);
            }
            else
                MessageBox.Show("Все хорошо", "Молодец!", MessageBoxButton.OK, MessageBoxImage.None);
        }
    }
}
