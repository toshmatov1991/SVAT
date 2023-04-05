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
        private int idPersonData = 0;
        public PersonData()
        {
            InitializeComponent();
        }

        public PersonData(int idPerson)
        {
            InitializeComponent();
            idPersonData = idPerson;
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

            foreach (var item in listObjPersonData)
            {
                if(string.IsNullOrEmpty(item))
                {
                    MessageBox.Show("Вы пропустили одно или несколько полей", "Незаполненное поле");
                }
            }

            









        }















    }
}
