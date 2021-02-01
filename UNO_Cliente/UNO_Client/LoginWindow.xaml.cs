using System;
using System.ServiceModel;
using System.Windows;
namespace UNO_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Btn_Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow
            {
                Owner = this
            };
            this.Hide();
            registerWindow.ShowDialog();
        }

        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Username.Text != "" && pb_Password.Password != "")
            {
                int result;
                
                InstanceContext context = new InstanceContext(this);
                Proxy.LoginServicesClient client = new Proxy.LoginServicesClient();
                try
                {
                    result = client.Login(tb_Username.Text, pb_Password.Password);
                    LoginVerification(result);
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

        private void Btn_Password_Recovery(object sender, RoutedEventArgs e)
        {
            RecoverPassword recoverPassword = new RecoverPassword
            {
                Owner = this
            };
            this.Hide();
            recoverPassword.ShowDialog();
        }

        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            this.Owner.ShowDialog();
        }

        public void LoginVerification(int result)
        {
            Console.WriteLine("Entro a login verification " + result);

            switch(result)
            {
                case 1:
                    this.Dispatcher.Invoke(() =>
                    {
                        lb_LoginError.Content = "";
                        GameMainMenuWindow gameMainMenuWindow = new GameMainMenuWindow();
                        this.Hide();
                        gameMainMenuWindow.ShowDialog();
                    });
                    break;
                case 2:
                    this.Dispatcher.Invoke(() =>
                    {
                        lb_LoginError.Content = "";
                        MessageRecoveryPasswordError messageRecoveryPasswordError = new MessageRecoveryPasswordError
                        {
                            Owner = this
                        };
                        messageRecoveryPasswordError.ShowDialog();
                    });
                    break;
                case 3:
                    this.Dispatcher.Invoke(() =>
                    {
                        lb_LoginError.Content = "El jugador ya tiene sesion iniciada";
                    });
                    break;
                case 4:
                    this.Dispatcher.Invoke(() =>
                    {
                        lb_LoginError.Content = "El jugador no se ha verificado";
                    });
                    break;
            }
        }
    }
}
