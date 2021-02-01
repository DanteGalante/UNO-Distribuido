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

        private void Btn_CreateRoom(object sender, RoutedEventArgs e)
        {
            
        }

        private void Btn_Join(object sender, RoutedEventArgs e)
        {
         
        }

        private void Btn_Scorers(object sender, RoutedEventArgs e)
        {
            BestScorers bestScorers = new BestScorers
            {
                Owner = this
            };
            this.Hide();
            bestScorers.ShowDialog();
            this.Close();
        }
        
        private void Btn_Report_Click(object sender, RoutedEventArgs e)
        {
            ReportPlayer reportPlayer = new ReportPlayer
            {
                Owner = this
            };
            this.Hide();
            reportPlayer.ShowDialog();
            this.Close();
        }

        private void Btn_ChangePassword(object sender, RoutedEventArgs e)
        {
            ChangePassword changePassword = new ChangePassword
            {
                Owner = this
            };
            this.Hide();
            changePassword.ShowDialog();
            this.Close();
        }

        private void Btn_Back(object sender, RoutedEventArgs e)
        { 
            LoginWindow loginWindow = new LoginWindow
            {
                Owner = this
            };
            this.Hide();
            loginWindow.ShowDialog();
            this.Close();
        }

        
    }


}
