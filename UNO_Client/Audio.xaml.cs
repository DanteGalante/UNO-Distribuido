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
    /// Lógica de interacción para Audio.xaml
    /// </summary>
    public partial class Audio : Window
    {
        public Audio()
        {
            InitializeComponent();
        }

        private void Btn_Done_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            this.Owner.ShowDialog();
        }
    }
}
