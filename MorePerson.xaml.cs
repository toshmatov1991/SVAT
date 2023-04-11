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
            






        }
    }
}
