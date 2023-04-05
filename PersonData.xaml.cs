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
    public partial class PersonData : Window
    {
        private int idWorkPersonData = 0;
        public PersonData()
        {
            InitializeComponent();
        }

        public PersonData(int idPerson)
        {
            InitializeComponent();
            idWorkPersonData = idPerson;
        }


        //Добавить призывника в базу
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            /*
             Список объектов XAML
            family
            name
            lastname
            datapic
            adressPropiska
            adressFact
            familyStatus
            category
            children
            socialStatus
            snils
            statusProsto
            serial
            number
             */

            //Проверка на пустые поля
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
                if(string.IsNullOrEmpty(item))
                {
                    CheckIsNull = true; 
                }
            }

            if(CheckIsNull)
            {
                MessageBox.Show("Вы пропустили одно или несколько полей", "Внимательно");
            }

            else
            {
                if(StrTrue(family.Text) 
                    && StrTrue(name.Text) 
                    && StrTrue(lastname.Text) 
                    && StrTrue(socialStatus.Text) 
                    && IntTrue(children.Text) 
                    && IntTrue(serial.Text) 
                    && IntTrue(number.Text))
                {
                    //Добавляю в БД запись о призывнике
                    using (PrContext db = new())
                    {

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
