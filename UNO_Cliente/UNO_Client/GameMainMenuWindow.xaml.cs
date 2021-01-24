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
    /// Interaction logic for GameMainMenuWindow.xaml
    /// </summary>
    public partial class GameMainMenuWindow : Window
    {
        public GameMainMenuWindow()
        {
            InitializeComponent();
        }

        private void Btn_Scorers(object sender, RoutedEventArgs e)
        {
            BestScorers bestScorers = new BestScorers();
            bestScorers.Owner = this;
            this.Hide();
            bestScorers.ShowDialog();
            this.Close();
        }

        private void Btn_CreateRoom(object sender, RoutedEventArgs e)
        {
            
        }

        private void Btn_Join(object sender, RoutedEventArgs e)
        {
         
        }

        private void Btn_Back(object sender, RoutedEventArgs e)
        {
            this.Hide();
            this.Owner.ShowDialog();
        }
    }


}
