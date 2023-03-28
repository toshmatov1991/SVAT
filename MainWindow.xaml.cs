using Soliders.Models;
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


        private void openWin_Click(object sender, RoutedEventArgs e)
        {
            //При нажатии на кнопку Войти
            if (string.IsNullOrEmpty(polzovatel.Text) && string.IsNullOrEmpty(password_user.Password)
                || string.IsNullOrEmpty(polzovatel.Text) || string.IsNullOrEmpty(password_user.Password))
            {
                MessageBox.Show("Вы пропустили одно или несколько полей", "Внимательно!", MessageBoxButton.OK, MessageBoxImage.None);
                if (polzovatel.Text == "")
                {
                    polzovatel.BorderBrush = Brushes.Red;
                }
              
                if (password_user.Password == "")
                {
                    password_user.BorderBrush = Brushes.Red;
                }
            }
            else
            {
                using(PrContext db = new())
                {
                    var getmyworks = db.Works.ToList();
                    bool stage = false;
                    foreach (var item in getmyworks)
                    {
                        if(polzovatel.Text == item.Login && password_user.Password == item.Pass)
                        {
                            stage= true;
                            User user = new($"{item.Firstname} {item.Name} {item.Lastname}");
                            user.Show();
                            Close();
                        }
                    }
                    if (!stage)
                    {
                        foreach (var item in getmyworks)
                        {
                            int y = 0;
                            //Если неправильный логин, то подсвечиваю рамку красным
                            if (polzovatel.Text != item.Login)
                            {
                                //ПОКА ЗАБИл
                                polzovatel.BorderBrush = Brushes.Red;
                            }
                            
                        }
                        foreach (var item in getmyworks)
                        {
                            //Если пароль неправильный, тоже самое
                            if (password_user.Password != item.Pass)
                            {
                                password_user.BorderBrush = Brushes.Red;
                            }
                        }
                        MessageBox.Show("Неправильный логин или пароль", "Внимательно!", MessageBoxButton.OK, MessageBoxImage.None);
                    }
                }
               
            }
               
        }







        #region При нажатии на кнопку меняем красную рамку на черный
        private void GoBlack(object sender, KeyEventArgs e)
        {
            polzovatel.BorderBrush = Brushes.Black;
        }

        private void GoGoBlack(object sender, KeyEventArgs e)
        {
            password_user.BorderBrush = Brushes.Black;
        }
        #endregion

        private void Check(object sender, KeyEventArgs e)
        {
            //При нажатии на Enter когда курсор в логине
            if (e.Key == Key.Enter)
                openWin_Click(sender, e);


        }

        private void CheckPas(object sender, KeyEventArgs e)
        {
            //При нажатии на Enter когда курсор на пароле
            if (e.Key == Key.Enter)
                openWin_Click(sender, e);
        }
    }
}
