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
        Controller controller = new Controller();

        public MainWindow()
        {
            InitializeComponent(); 
            
        }
        

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            int id = controller.logIn(Username.Text, Password.Text);

            if (id > 0 && id < 3) {

            }
            else if (id == 3) {

            }
            else if (id > 3) {

            }
            else {
                MessageBox.Show("Username and Password does not match");
            }
   
        }
    }
}
