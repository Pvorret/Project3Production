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
    /// Interaction logic for MaskineVindue.xaml
    /// </summary>
    public partial class MaskineVindue : Window
    {
        OpretArbejdsplan opretArbejdsplanMenu = new OpretArbejdsplan();
        public MaskineVindue()
        {
            InitializeComponent();
            MachineNameLabel.Content = OpretArbejdsplan.SelectedMachine; 
        }


        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
