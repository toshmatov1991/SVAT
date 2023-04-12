using iText.Kernel.XMP.Impl;
using Microsoft.EntityFrameworkCore;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Soliders
{
   
    public partial class MorePerson : Window
    {
        int mestniyId = 0;
        public MorePerson(int idMore)
        {
            InitializeComponent();
            mestniyId = idMore;
            PullUpPersona();
        }

             /* family.Text, 
                name.Text, 
                lastname.Text, 
                datapic.Text, 
                adressPropiska.Text, 
                adressFact.Text, 
                familyStatus.Text, 
                category.Text, 
                children.Text, 
                socialStatus.Text,
                snils.Text,
                statusProsto.Text,
                serial.Text,
                number.Text
             */

        private void PullUpPersona()
        {
            using (PrContext db = new())
            {
                //Запрос
                var getMyPerson = db.Conscripts.Where(u => u.Id == mestniyId).ToList();

                family.Text = getMyPerson.First().Firstname;
                name.Text = getMyPerson.First().Name;
                lastname.Text = getMyPerson.First().Lastname;
                datapic.Text = getMyPerson.First().Dateof;
                adressPropiska.Text = getMyPerson.First().Address;
                adressFact.Text = getMyPerson.First().AddressNext;
                familyStatus.Text = getMyPerson.First().FamilyStatus;
                category.Text = getMyPerson.First().Category;
                children.Text = getMyPerson.First().Children.ToString();
                socialStatus.Text = getMyPerson.First().SocialStatus;
                snils.Text = getMyPerson.First().Snils;
                statusProsto.Text = getMyPerson.First().Status;
                serial.Text = getMyPerson.First().Passport.Substring(0, 4);
                number.Text = getMyPerson.First().Passport.Substring(4);
            }
        }

        //Изменить информацию о призывнике/физическом лице
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var listObjPersonData = new List<string>()
            {
                family.Text,
                name.Text,
                lastname.Text,
                datapic.Text,
                adressPropiska.Text,
                adressFact.Text,
                familyStatus.Text,
                category.Text,
                children.Text,
                socialStatus.Text,
                snils.Text,
                statusProsto.Text,
                serial.Text,
                number.Text
            };


            bool CheckIsNull = false;

            foreach (var item in listObjPersonData)
            {
                if (string.IsNullOrEmpty(item))
                {
                    CheckIsNull = true;
                }
            }

            if (CheckIsNull)
            {
                MessageBox.Show("Вы пропустили одно или несколько полей", "Внимательно");
            }

            else
            {
                number.Text = number.Text.Replace(" ", "");
                if (StrTrue(family.Text)
                    && StrTrue(name.Text)
                    && StrTrue(lastname.Text)
                    && StrTrue(socialStatus.Text)
                    && IntTrue(children.Text)
                    && IntTrue(serial.Text)
                    && IntTrue(number.Text))
                {
                    try
                    {
                        //Добавляю в БД запись о призывнике
                        using (PrContext db = new())
                        {
                            var MyPerson = db.Conscripts.Where(u => u.Id == mestniyId).FirstOrDefault();

                            MyPerson.Firstname = family.Text;
                            MyPerson.Lastname = lastname.Text;
                            MyPerson.Name = name.Text;
                            MyPerson.Dateof = datapic.Text;
                            MyPerson.Address = adressPropiska.Text;
                            MyPerson.AddressNext = adressFact.Text;
                            MyPerson.FamilyStatus = familyStatus.Text;
                            MyPerson.Category = category.Text;
                            MyPerson.Children = Convert.ToInt64(children.Text);
                            MyPerson.SocialStatus = socialStatus.Text;
                            MyPerson.Snils = snils.Text;
                            MyPerson.Passport = serial.Text + " " + number.Text;
                            MyPerson.Status = statusProsto.Text;

                            db.SaveChanges();

                        }
                        MessageBox.Show("Данные изменены");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

                else
                    MessageBox.Show("Некорректно заполнено одно из полей");
            }


            static bool IntTrue(string str)
            {
                int j = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    if (!char.IsDigit(str[i]))
                        j++;
                }

                if (j == 0)
                    return true;
                else
                    return false;
            }


            static bool StrTrue(string str)
            {
                int j = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    if (!char.IsLetter(str[i]))
                        j++;
                }

                if (j == 0)
                    return true;
                else
                    return false;
            }


        }
    }
}
