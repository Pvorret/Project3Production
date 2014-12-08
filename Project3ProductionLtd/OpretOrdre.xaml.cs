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
    /// Interaction logic for OpretOrdre.xaml
    /// </summary>
    public partial class OpretOrdre : Window {
        MainMenuSælger menuSælger;
        public OpretOrdre() {
            InitializeComponent();
        }

        private void CancelBt_Click(object sender, RoutedEventArgs e) {
            menuSælger = new MainMenuSælger();
            menuSælger.Show();
        }

        private void ProductTypeDropdown_DropDownOpened(object sender, EventArgs e) {
            for (int i = 0; i < Controller.productList.Count; i++) {
                ProductTypeDropdown.Items.Add(Controller.productList[i].Name);

            }
        }

        private void TypeDropdown_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

       


    }
}
