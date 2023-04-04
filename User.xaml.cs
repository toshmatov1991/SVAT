using Soliders.Models;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Soliders
{
    public partial class User : Window
    {
        public User()
        {
            InitializeComponent();
            ListConscripts();
        }

        public User(string iduser)
        {
            InitializeComponent();
            Title = iduser;
            ListConscripts();
        }

        private void ListConscripts()
        {
            using(PrContext db = new())
            {
                var listConscripts = from conscript in db.Conscripts
                                     select new
                                     {
                                         conscript.Id,
                                         Firstname = conscript.Firstname,
                                         Lastname = conscript.Lastname,
                                         Name = conscript.Name,
                                         DateOfBirth = conscript.Dateof,
                                         Category = conscript.Category,
                                         Passport = conscript.Passport,
                                         Snils = conscript.Snils,
                                         Status = conscript.Status
                                     };
                listviewUsers.ItemsSource = listConscripts.ToList();
            }
        }


        /*Поиск призывников*/
        private void FaceSearch(object sender, KeyEventArgs e)
        {

        }


        /*Добавить новую запись(призывника, физическое лицо)*/
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
