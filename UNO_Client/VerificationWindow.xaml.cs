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

namespace UNO_Client
{
    /// <summary>
    /// Interaction logic for VerificationWindow.xaml
    /// </summary>
    public partial class VerificationWindow : Window
    {
        private string playerUsername = "";
        public VerificationWindow()
        {
            InitializeComponent();
        }

        public VerificationWindow(string username)
        {
            InitializeComponent();
            playerUsername = username;
        }

        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            this.Owner.ShowDialog();
        }

        private void Btn_Verify_Click(object sender, RoutedEventArgs e)
        {
            InstanceContext instanceContext = new InstanceContext(this);
            Proxy.PlayerManagerClient client = new Proxy.PlayerManagerClient(instanceContext);

            bool result = false;

            try
            {
                result = client.VerifyPlayer(playerUsername);

                if (result = false)
                {

                }
                else
                {

                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
