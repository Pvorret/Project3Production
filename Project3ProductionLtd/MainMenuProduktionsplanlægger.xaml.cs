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

namespace Project3ProductionLtd {
    /// <summary>
    /// Interaction logic for MainMenuProduktionsplanlægger.xaml
    /// </summary>
    public partial class MainMenuProduktionsplanlægger : Window {

        MainWindow mainWin;
        OpretArbejdsplan opretArbejdsplan;
        BekræftOrdreWindow bekræftOrdre;
        public MainMenuProduktionsplanlægger() 
        {
            InitializeComponent();
            if (Controller.isOrderConfirmed() > 0)
            {
                UnConfirmedOrderLabel.Content = Controller.isOrderConfirmed();
            }
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            mainWin = new MainWindow();
            mainWin.Show();
            Close();
        }

        private void OpretArbejdsplanBtn_Click(object sender, RoutedEventArgs e)
        {
            opretArbejdsplan = new OpretArbejdsplan();
            opretArbejdsplan.Show();
            Close();
        }

        private void orders_Click(object sender, RoutedEventArgs e)
        {
            bekræftOrdre = new BekræftOrdreWindow();
            bekræftOrdre.Show();
            Close();
        }
    }
}
