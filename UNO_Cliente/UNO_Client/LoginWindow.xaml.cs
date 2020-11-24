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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using UNO_Client.LoginServicesProxy;

namespace UNO_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class LoginWindow : Window, ILoginServicesCallback
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Btn_Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Owner = this;
            this.Hide();
            registerWindow.ShowDialog();
        }

        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            InstanceContext context = new InstanceContext(this);
            LoginServicesClient client = new LoginServicesClient(context);
            //try
            //{
                client.Login(tb_Username.Text, pb_Password.Password);
            //}
            //catch (EndpointNotFoundException exception)
            //{
                //Console.WriteLine("No se pudo realizar la conexión con el servidor \n" + exception);
                //lb_LoginError.Content = "Error en la conexión con el servidor";
            //}
            //catch (TimeoutException exception)
            //{
                //Console.WriteLine("No se pudo realizar la conexion con el servidor por tiempo \n" + exception);
                //lb_LoginError.Content = "Error en la conexion con el servidor";
            //}
        }

        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            this.Owner.ShowDialog();
        }

        public void LoginVerification(bool result)
        {
            Console.WriteLine("Entro a login verification " + result);
            
            if (result == true)
            {
                this.Dispatcher.Invoke(() =>
                {
                    lb_LoginError.Content = "";
                    GameMainMenuWindow gameMainMenuWindow = new GameMainMenuWindow();
                    this.Hide();
                    gameMainMenuWindow.ShowDialog();
                });
            }
            else
            {
                //this.Dispatcher.Invoke(ModifyLabels(lb_LoginError, "Nombre de usuario o contraseña incorrectos") =>)
                this.Dispatcher.Invoke(() =>
                {
                    lb_LoginError.Content = "Nombre de usuario o contraseña incorrectos";
                });
            }
        }

        public void IsLoggedResult(bool result)
        {
            throw new NotImplementedException();
        }
    }
}
