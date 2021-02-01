using System.Windows;
using System;
using System.ServiceModel;
using UNO_Client.Proxy;

namespace UNO_Client

{
    /// <summary>
    /// Lógica de interacción para RecoverPassword.xaml
    /// </summary>
    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class RecoverPassword : Window
    {
        public RecoverPassword()
        {
            InitializeComponent();
        }
        
        private void Btn_SendMeEmail(object sender, RoutedEventArgs e)
        {
            if (tb_UserName.Text != "" && tb_Email.Text != "")
            {
                bool result = false;

                InstanceContext instanceContext = new InstanceContext(this);
                Proxy.PlayerManagerClient client = new PlayerManagerClient();
                try
                {
                    result = client.SendPassword(tb_UserName.Text, tb_Email.Text);

                    if (result == false)
                    {
                        MessageRecoveryPasswordError messageChangeError = new MessageRecoveryPasswordError
                        {
                            Owner = this
                        };
                        messageChangeError.ShowDialog();
                    }
                    else
                    {
                        MessageRecoveryPassword messageRecoveryPassword = new MessageRecoveryPassword
                        {
                            Owner = this
                        };
                        messageRecoveryPassword.ShowDialog();
                    }
                }
                catch (EndpointNotFoundException exception)
                {
                    Console.WriteLine("No se pudo realizar la conexión con el servidor \n" + exception);
                    MessageConnection messageConnectionLost = new MessageConnection
                    {
                        Owner = this
                    };
                    messageConnectionLost.ShowDialog();
                }
                catch (TimeoutException exception)
                {
                    Console.WriteLine("No se pudo realizar la conexion con el servidor por tiempo \n" + exception);
                    MessageConnection messageConnectionLost = new MessageConnection
                    {
                        Owner = this
                    };
                    messageConnectionLost.ShowDialog();
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

        private void Btn_Back(object sender, RoutedEventArgs e)
        {
            this.Hide();
            this.Owner.ShowDialog();
        }
    }
}
