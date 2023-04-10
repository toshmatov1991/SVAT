﻿using Soliders.Models;
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
        private static int idPerson = 1;
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

            using(PrContext db = new())
            {
                var getMyRabs = db.Works.Where(u => u.Id == idPerson).FirstOrDefault();
                if (getMyRabs != null)
                {

                }
                else
                    MessageBox.Show("Что то пошло не так, мдаа......");
            }




        }

        //Метод для заполнения списка пользователей
        private void ListWorks()
        {
            using (PrContext db = new())
            {
                var listWorks = db.Works.ToList();
                listviewUsers.ItemsSource = listWorks;

                var getMyWorks = db.Works.FirstOrDefault();

                family.Text = getMyWorks.Firstname;
                name.Text = getMyWorks.Name;
                lastname.Text = getMyWorks.Lastname;
                login.Text = getMyWorks.Login;
                password.Text = getMyWorks.Pass;
                if (getMyWorks.Admin == 1)
                    administratorRights.IsChecked = true;
                else administratorRights.IsChecked = false;
                if (getMyWorks.Block == 1)
                    block.IsChecked = true;
                else block.IsChecked = false;
            }
        }

    }
}
