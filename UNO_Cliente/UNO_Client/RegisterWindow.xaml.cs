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
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        //Work in progress
        private void Btn_RegisterNewUser_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Username.Text != "" && pb_Password.Password != "" && tb_Name.Text != "" && tb_LastName.Text != "" && tb_Email.Text != "")
            {
                InstanceContext instanceContext = new InstanceContext(this);
                Proxy.PlayerManagerClient client = new PlayerManagerClient();
                int response = 0;


                Player newPlayer = new Player
                {
                    username = tb_Username.Text,
                    password = pb_Password.Password,
                    name = tb_Name.Text,
                    lastnames = tb_LastName.Text,
                    isBanned = false,
                    verificationToken = "",
                    isLogged = false,
                    isVerified = false,
                    email = tb_Email.Text,
                    points = 0,
                    AccumulatedReports = 0                    
                };

                try
                {
                    response = client.RegisterPlayer(newPlayer);

                    VerificationWindow verificationWindow = null;

                    switch (response)
                    {
                        case 1:
                            this.Dispatcher.Invoke(() =>
                            {
                                MessageRegister messageRegister = new MessageRegister
                                {
                                    Owner = this
                                };
                                messageRegister.ShowDialog();

                                lb_RegistrationError.Content = "";
                                verificationWindow = new VerificationWindow(newPlayer.username)
                                {
                                    Owner = this
                                };
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
                                verificationWindow = new VerificationWindow(newPlayer.username);
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
                }
                catch (EndpointNotFoundException exception)
                {
                    Console.WriteLine("No se pudo realizar la conexión con el servidor \n" + exception);
                    MessageConnection message01 = new MessageConnection
                    {
                        Owner = this
                    };
                    message01.ShowDialog();
                }  
                catch (TimeoutException exception)
                {
                    Console.WriteLine("No se pudo realizar la conexion con el servidor por tiempo \n" + exception);
                    MessageConnection message01 = new MessageConnection
                    {
                        Owner = this
                    };
                    message01.ShowDialog();
                }
            }
            else
            {
                MessageFields messageFields = new MessageFields
                {
                    Owner = this
                };
                messageFields.ShowDialog();
            }
        }

        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            this.Owner.ShowDialog();
        }

        private void Hide_Click(object sender, RoutedEventArgs e)
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
