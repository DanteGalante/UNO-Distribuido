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
    /// Lógica de interacción para ReportPlayer.xaml
    /// </summary>
    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class ReportPlayer : Window
    {
        public ReportPlayer()
        {
            InitializeComponent();
        }

        private void Btn_report_click(object sender, RoutedEventArgs e)
        {
            if(tb_UserName.Text != "" && rb_AN.IsChecked == true || rb_VA.IsChecked == true || rb_L.IsChecked == true)
            {
                bool result;
                InstanceContext instanceContext = new InstanceContext(this);
                Proxy.PlayerManagerClient client = new PlayerManagerClient();
                try
                {
                    result = client.ReportPlayer(tb_UserName.Text);
                    if(result == true)
                    {
                        MessageReport messageReport = new MessageReport
                        {
                            Owner = this
                        };
                        messageReport.ShowDialog();
                    }
                    else
                    {
                        MessageReportError messageReportError = new MessageReportError
                        {
                            Owner = this
                        };
                        messageReportError.ShowDialog();
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

        private void Btn_back_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            this.Owner.ShowDialog();
        }
    }
}
