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
    /// Interaction logic for OpretArbejdsplan.xaml
    /// </summary>
    /// 
    public partial class OpretArbejdsplan : Window
    {
        MainMenuProduktionsplanlægger menuPlanlægger;
        public OpretArbejdsplan()
        {
            InitializeComponent();
            
            ProductDropdown.Visibility = System.Windows.Visibility.Hidden;
            ProductLabel.Visibility = System.Windows.Visibility.Hidden;
            ProductNameLabel.Visibility = System.Windows.Visibility.Hidden;
            MachineAvailableLabel.Visibility = System.Windows.Visibility.Hidden;
            MachineAvailableListBox.Visibility = System.Windows.Visibility.Hidden;
            MachineRequiredLabel.Visibility = System.Windows.Visibility.Hidden;
            MachineRequiredListBox.Visibility = System.Windows.Visibility.Hidden;

        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            menuPlanlægger = new MainMenuProduktionsplanlægger();
            menuPlanlægger.Show();
            Close();
        }
    }
}
