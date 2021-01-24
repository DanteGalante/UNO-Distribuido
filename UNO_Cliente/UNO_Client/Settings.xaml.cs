using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Lógica de interacción para Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Btn_Audio_Click(object sender, RoutedEventArgs e)
        {
            Audio audio = new Audio();
            audio.Owner = this;
            this.Hide();
            audio.ShowDialog();
            this.Close();
        }

        private void Btn_Language_Click(object sender, RoutedEventArgs e)
        {
            ChangeLanguage changeLanguage = new ChangeLanguage();
            changeLanguage.Owner = this;
            this.Hide();
            changeLanguage.ShowDialog();
            this.Close();
        }

        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            this.Owner.ShowDialog();
        }
    }
}
