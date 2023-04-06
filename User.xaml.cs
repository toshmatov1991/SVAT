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

        public User(int idUs, string iduser, int idAdmin)
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
            PersonData person = new();
            person.ShowDialog();
        }


        /*Подробнее о персоне*/
        private void MoreAboutThePerson(object sender, MouseButtonEventArgs e)
        {
            var str = listviewUsers.SelectedItem.ToString();
            MessageBox.Show(ReturnIdThePerson(str));





            static string ReturnIdThePerson(string a)
            {
                string strId = "";
                for (int i = 0; i < a.Length; i++)
                {
                    if (char.IsDigit(a[i]))
                        strId += a[i];
                    else if (a[i] == ',')
                        break;
                }
                return strId;
            }
        }

        /*Добавить новую запись(сотудника, физическое лицо)*/
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddAdmin addAdmin = new();
            addAdmin.ShowDialog();
        }



        /*Список сотрудников(администрирование)*/
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ListPersonWorks listPersonWorks = new ListPersonWorks();
            listPersonWorks.ShowDialog();
        }
    }
}
