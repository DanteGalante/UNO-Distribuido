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
        }

        private void Btn_Verify_Click(object sender, RoutedEventArgs e)
        {
            InstanceContext instanceContext = new InstanceContext(this);
            Proxy.PlayerManagerClient client = new Proxy.PlayerManagerClient();

            bool result = false;

            try
            {
                result = client.VerifyPlayer(playerUsername, tb_VerificationToken.Text);

                if (result == false)
                {
                    MessageErrorVerification messageErrorVerification = new MessageErrorVerification
                    {
                        Owner = this
                    };
                    messageErrorVerification.ShowDialog();
                }
                else
                {
                    MessageVerification messageVerification = new MessageVerification
                    {
                        Owner = this
                    };
                    messageVerification.ShowDialog();

                    LoginWindow loginWindow = new LoginWindow
                    {
                        Owner = this
                    };
                    this.Hide();
                    loginWindow.ShowDialog();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
