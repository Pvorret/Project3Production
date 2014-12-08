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

namespace Project3ProductionLtd
{
    /// <summary>
    /// Interaction logic for MainMenuSælger.xaml
    /// </summary>
    public partial class MainMenuSælger : Window
    {
        MainWindow mainWin;
        OpretOrdre opretordre;
        public MainMenuSælger()
        {
            InitializeComponent();
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            mainWin = new MainWindow();
            mainWin.Show();
            Close();

        }

        private void makeorder_Click(object sender, RoutedEventArgs e) {
            opretordre = new OpretOrdre();
            opretordre.Show();
            Close();
        }
    }
}
