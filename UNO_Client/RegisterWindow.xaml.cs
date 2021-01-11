using System;
using System.ServiceModel;
using System.Windows;
using UNO_Client.Proxy;

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

            Player newPlayer = new Player();
            newPlayer.username = tb_Username.Text;
            newPlayer.password = pb_Password.Password;
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

        public void GetPlayersResponse(Player[] players)
        {
            throw new NotImplementedException();
        }

        public void VerifyPlayerRegistration(int response, string username)
        {
            VerificationWindow verificationWindow = null;

            switch (response)
            {
                case 1:
                    this.Dispatcher.Invoke(() =>
                    {
                        lb_RegistrationError.Content = "";
                        verificationWindow = new VerificationWindow(username);
                        verificationWindow.Owner = this;
                        this.Hide();
                        verificationWindow.ShowDialog();
                    });
                    break;
                case 2:
                    this.Dispatcher.Invoke(() =>
                    {
                        lb_RegistrationError.Content = "El jugador ya esta registrado en el sistema";
                    });
                    break;
                case 3:
                    //Cuando llega al dispatcher se traba por alguna razon
                    this.Dispatcher.Invoke(() =>
                    {
                        lb_RegistrationError.Content = "";
                        verificationWindow = new VerificationWindow(username);
                        verificationWindow.Owner = this;
                        this.Hide();
                        verificationWindow.ShowDialog();
                    });
                    break;
                case 4:
                    this.Dispatcher.Invoke(() =>
                    {
                        lb_RegistrationError.Content = "El correo electronico introducido no esta disponible";
                    });
                    break;
                case 5:
                    this.Dispatcher.Invoke(() =>
                    {
                        lb_RegistrationError.Content = "El nombre de usuario introducido no esta disponible";
                    });
                    break;
            }

            /*
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
            */
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
