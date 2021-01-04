using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
using UNO_Client.Proxy;

namespace UNO_Client
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window, IPlayerManagerCallback
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Btn_RegisterNewUser_Click(object sender, RoutedEventArgs e)
        {
            InstanceContext instanceContext = new InstanceContext(this);
            Proxy.PlayerManagerClient client = new PlayerManagerClient(instanceContext);

            Player newPlayer = new Player();
            newPlayer.username = tb_Username.Text;
            //newPlayer.password = tb_


            try
            {
                //client.AddNewPlayer());
            }
            catch
            {

            }
        }

        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            this.Owner.ShowDialog();
        }

        public void VerifyPlayerAddition(bool response)
        {
            throw new NotImplementedException();
        }

        public void VerifyPlayerDeletion(bool response)
        {
            throw new NotImplementedException();
        }

        public void VerifyPlayerModification(bool response)
        {
            throw new NotImplementedException();
        }

        public void GetPlayersResponse(Player[] players)
        {
            throw new NotImplementedException();
        }

        public void VerifyPlayerRegistration(bool response)
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(pb_Password.PasswordChar);

            if(pb_Password.PasswordChar == '\0')
            {
                pb_Password.PasswordChar = '●';
            }
            pb_Password.PasswordChar = '\0';
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (pb_Password.IsVisible)
            {
                tb_Password.Visibility = Visibility.Visible;
                pb_Password.Visibility = Visibility.Hidden;

                tb_Password.Text = pb_Password.Password;
            }
            else
            {
                tb_Password.Visibility = Visibility.Hidden;
                pb_Password.Visibility = Visibility.Visible;

                pb_Password.Password = tb_Password.Text;
                tb_Password.Text = "";
            }
        }
    }
}
