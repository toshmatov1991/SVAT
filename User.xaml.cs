using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Soliders
{
    public partial class User : Window
    {
        public User()
        {
            InitializeComponent(); 
        }

        public User(string iduser)
        {
            InitializeComponent();
            Title = iduser;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //AppDomain.CurrentDomain.BaseDirectory
            var str = AppDomain.CurrentDomain.BaseDirectory;

            MessageBox.Show(str, "Абсолютный путь");


           




            

           


        }
    }
}
