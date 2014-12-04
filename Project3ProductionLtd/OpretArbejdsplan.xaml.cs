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
            
            ProductDropdown.IsEnabled = false;
            ProductLabel.IsEnabled = false;
            ProductNameLabel.IsEnabled = false;
            MachineAvailableLabel.IsEnabled = false;
            MachineAvailableListBox.IsEnabled = false;
            MachineRequiredLabel.IsEnabled = false;
            MachineRequiredListBox.IsEnabled = false;

        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            menuPlanlægger = new MainMenuProduktionsplanlægger();
            menuPlanlægger.Show();
            Close();
            
        }

        private void OrderDropdown_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        private void OrderDropdown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

            for (int i = 0; i < Controller.orderList.Count; i++)
            {
                foreach (Order name in Controller.orderList)
                {
                    ProductDropdown.Items.Remove(name.OrderName);
                }
                if (OrderDropdown.SelectedItem == Controller.orderList[i].OrderName)
                {
                    ProductDropdown.Items.Add(Controller.orderList[i].OrderProductName1);
                    ProductDropdown.Items.Add(Controller.orderList[i].OrderProductName2);
                }
            }
            
            ProductDropdown.IsEnabled = true;

        }
        
        private void OrderDropdown_DropDownOpened(object sender, EventArgs e)
        {
            if (OrderDropdown.Items.Count == 0)
            {
            foreach (Order orderName in Controller.getOrdersFromDatabaseToOrderList())
            {
                OrderDropdown.Items.Add(orderName.OrderName);
            }
        }
    }

        private void ProductDropdown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
}
}
