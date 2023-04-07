using Soliders.Models;
using System;
using System.Collections.Generic;
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
    public partial class ListPersonWorks : Window
    {
        public ListPersonWorks()
        {
            InitializeComponent();
            ListWorks();
        }

        /*Изменить данные*/
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*Объекты XAML
            family
            name
            lastname
            login
            password
            administratorRights
            block 
             */

        }

        private void ListWorks()
        {
            using (PrContext db = new())
            {
                var listWorks = db.Works.ToList();
                listviewUsers.ItemsSource = listWorks;
            }
        }

    }
}
