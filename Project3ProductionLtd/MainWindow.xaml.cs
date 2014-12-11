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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project3ProductionLtd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainMenuSælger menuSælger;
        MainMenuProduktionsplanlægger menuPlanlægger;
        MainMenuProduktionsarbejder menuArbejder;
        public MainWindow()
        {
            InitializeComponent(); 
            
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {

            int id = Controller.logIn(Username.Text, Password.Password);

            if (id > 0 && id < 3) {
                menuSælger = new MainMenuSælger();
                if (id == 1)
                {
                    menuSælger.usernameLabel.Content = "Anders";
                }
                if (id == 2)
                {
                    menuSælger.usernameLabel.Content = "Lisa";
                }
                menuSælger.Show();
                Close();
            }
            else if (id == 3) {
                menuPlanlægger = new MainMenuProduktionsplanlægger();
                menuPlanlægger.PlanlæggerLabel.Content = "Hanne";
                menuPlanlægger.Show();
                Close();
            }
            else if (id > 3) {
                menuArbejder = new MainMenuProduktionsarbejder();
                menuArbejder.Show();
                Close();
            }
            else {
                MessageBox.Show("Username and Password does not match");
            }
        
        }
         

        private void SælgerBtn_Click(object sender, RoutedEventArgs e)
        {
            menuSælger = new MainMenuSælger();
            menuSælger.Show();
            Close();
        }

        private void PlanlæggerBtn_Click(object sender, RoutedEventArgs e)
        {
            menuPlanlægger = new MainMenuProduktionsplanlægger();
            menuPlanlægger.Show();
            Close();
        }

        private void ArbejderBtn_Click(object sender, RoutedEventArgs e)
        {
            menuArbejder = new MainMenuProduktionsarbejder();
            menuArbejder.Show();
            Close();
        }

    }
}
