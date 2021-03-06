using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Globalization;


namespace UNO_Client
{
    /// <summary>
    /// Interaction logic for ChangeLanguage.xaml
    /// </summary>
    public partial class ChangeLanguage : Window
    {
        public ChangeLanguage()
        {
            InitializeComponent();            
        }

        private void Btn_English_Click(object sender, RoutedEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            Languages.WrapperLanguage.ChangeCulture(Thread.CurrentThread.CurrentUICulture);

            MessageChangeLanguage messageChangeLanguage = new MessageChangeLanguage
            {
                Owner = this
            };
            messageChangeLanguage.ShowDialog();
        }

 
        private void Btn_Spanish_Click(object sender, RoutedEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es");
            Languages.WrapperLanguage.ChangeCulture(Thread.CurrentThread.CurrentUICulture);

            MessageChangeLanguage messageChangeLanguage = new MessageChangeLanguage
            {
                Owner = this
            };
            messageChangeLanguage.ShowDialog();
        }

        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            this.Owner.ShowDialog();
        }
    }
}
