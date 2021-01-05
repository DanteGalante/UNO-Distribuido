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
using UNO_Server.Utilities;

namespace UNO_Client
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class RegisterWindow : Window, IPlayerManagerCallback
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        //Work in progress
        private void Btn_RegisterNewUser_Click(object sender, RoutedEventArgs e)
        {
            InstanceContext instanceContext = new InstanceContext(this);
            Proxy.PlayerManagerClient client = new PlayerManagerClient(instanceContext);
            DataManager dataManager = new DataManager();
            
            Player newPlayer = new Player();
            newPlayer.username = tb_Username.Text;
            newPlayer.password = dataManager.EncryptPassword(pb_Password.Password);
            newPlayer.name = tb_Name.Text;
            newPlayer.lastnames = tb_LastName.Text;
            //newPlayer.avatarImage =
            newPlayer.isBanned = false;
            newPlayer.verificationToken = "";
            newPlayer.isLogged = false;
            newPlayer.isVerified = false;
            newPlayer.email = tb_Email.Text;

            try
            {
                client.RegisterPlayer(newPlayer);
            }
            catch(EndpointNotFoundException exception)
            {
                Console.WriteLine("No se pudo realizar la conexión con el servidor \n" + exception);
                lb_RegistrationError.Content = "Error en la conexión con el servidor";
            }
            catch(TimeoutException exception)
            {
                Console.WriteLine("No se pudo realizar la conexion con el servidor por tiempo \n" + exception);
                lb_RegistrationError.Content = "Error en la conexion con el servidor";
            }
        }

        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            this.Owner.ShowDialog();
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
            if(response == true)
            {
                this.Dispatcher.Invoke(() =>
                {
                    lb_RegistrationError.Content = "";
                    VerificationWindow verificationWindow = new VerificationWindow();
                    this.Hide();
                    verificationWindow.ShowDialog();
                });
            }
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

        private void btn_LoadImage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
