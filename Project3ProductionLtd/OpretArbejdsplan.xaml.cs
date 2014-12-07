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
        MaskineVindue maskineVindue;
        public static string SelectedMachine { get; set; }

        public OpretArbejdsplan()
        {
            InitializeComponent();
            
            ProductDropdown.IsEnabled = false;
            ProductLabel.IsEnabled = false;
            ProductNameLabel.IsEnabled = false;
            MachineToEditLabel.IsEnabled = false;
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
                if (OrderDropdown.SelectedItem.Equals(Controller.orderList[i].OrderName))
                {
                    foreach (Order name in Controller.orderList)
                    {
                        ProductDropdown.Items.Remove(name.OrderProductName1);
                        ProductDropdown.Items.Remove(name.OrderProductName2);
                    }

                    if (Controller.orderList[i].OrderProductName1 != "")
                    {
                        ProductDropdown.Items.Add(Controller.orderList[i].OrderProductName1);
                        if (Controller.orderList[i].OrderProductName2 != "")
                        {
                        ProductDropdown.Items.Add(Controller.orderList[i].OrderProductName2);
                        }
                    }
                    else if (Controller.orderList[i].OrderProductName2 != "")
                    {
                        ProductDropdown.Items.Add(Controller.orderList[i].OrderProductName2);
                    }
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
            ProductLabel.IsEnabled = true;
            ProductNameLabel.IsEnabled = true;
            MachineToEditLabel.IsEnabled = true;
            MachineRequiredLabel.IsEnabled = true;
            MachineRequiredListBox.IsEnabled = true;
            for (int j = 0; j < Controller.orderList.Count; j++)
			{
                foreach (Product MachineName in Controller.getRequiredMachineFromProductDB(Controller.orderList[j].OrderProductName1))
                {
                    for (int k = 0; k < MachineName.machineList.Count; k++)
                    {
                        MachineRequiredListBox.Items.Remove(MachineName.machineList[k].Name);
                    } 
                }
                
                foreach (Product MachineName in Controller.getRequiredMachineFromProductDB(Controller.orderList[j].OrderProductName2))
                {
                    for (int k = 0; k < MachineName.machineList.Count; k++)
                    {
                        MachineRequiredListBox.Items.Remove(MachineName.machineList[k].Name);
                    }
                }
			}
            

            for (int i = 0; i < Controller.orderList.Count; i++)
            {
                if (ProductDropdown.SelectedItem.Equals(Controller.orderList[i].OrderProductName1))
                {
                    ProductNameLabel.Content = Controller.orderList[i].OrderProductName1;
                    foreach (Product MachineName in Controller.getRequiredMachineFromProductDB(Controller.orderList[i].OrderProductName1))
	                {
                        for (int k = 0; k < MachineName.machineList.Count; k++)
                        {
                            MachineRequiredListBox.Items.Add(MachineName.machineList[k].Name);
                        }
                    }
                    
                }
                else if (ProductDropdown.SelectedItem.Equals(Controller.orderList[i].OrderProductName2))
                {
                    ProductNameLabel.Content = Controller.orderList[i].OrderProductName2;
                    foreach (Product MachineName in Controller.getRequiredMachineFromProductDB(Controller.orderList[i].OrderProductName2))
                    {
                        for (int k = 0; k < MachineName.machineList.Count; k++)
                        {
                            MachineRequiredListBox.Items.Add(MachineName.machineList[k].Name);
                        }
                    }
                 }
             }
        }

       

       private void MachineRequiredListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
       {
           SelectedMachine = MachineRequiredListBox.SelectedItem.ToString();
           maskineVindue = new MaskineVindue();
           maskineVindue.Show();
       }
}
}
