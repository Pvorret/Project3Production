﻿using System;
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
    /// Interaction logic for BekræftOrdreWindow.xaml
    /// </summary>
    public partial class BekræftOrdreWindow : Window
    {
        MainMenuProduktionsplanlægger menuPlanlægger;
        public BekræftOrdreWindow()
        {
            InitializeComponent();
        }

        private void NewDeadline_Checked(object sender, RoutedEventArgs e)
        {
            Handle(sender as CheckBox);
        }

        private void NewDeadline_Unchecked(object sender, RoutedEventArgs e)
        {
            Handle(sender as CheckBox);
        }

        void Handle(CheckBox checkBox)
        {
            bool flag = checkBox.IsChecked.Value;

            if (NewDeadline.IsChecked == true)
            {
                ConfirmOrder.Content = "Estimate";
            }
            else
                ConfirmOrder.Content = "Confirm";
        }

        private void ConfirmOrder_Click(object sender, RoutedEventArgs e)
        {
            if (ConfirmOrder.Content == "Confirm")
            {
                Controller.confirmOrder(OrderSelected.SelectedItem.ToString());
            }
            else
            if (ConfirmOrder.Content == "Estimate")
            {
                List<Order> orders = new List<Order>();
                orders = Controller.getOrdersFromDatabaseToOrderList();
                for (int i = 0; i < orders.Count; i++)
                {
                    if (OrderSelected.SelectedItem.Equals(orders[i].OrderName))
                    {
                        Controller.newDeadline(OrderSelected.SelectedItem.ToString(), orders[i].Deadline);
                    }
                }
                orders = Controller.getOrdersFromDatabaseToOrderList();
                for (int i = 0; i < orders.Count; i++)
                {
                    if (OrderSelected.SelectedItem.Equals(orders[i].OrderName))
                    {
                        OrderDeadline.Content = orders[i].Deadline;
                    }
                }
                
            }
        }
        private void OrderSelected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Order> orders = new List<Order>();
            orders = Controller.getOrdersFromDatabaseToOrderList();
            for (int i = 0; i < orders.Count; i++)
            {
                if (OrderSelected.SelectedItem.Equals(orders[i].OrderName))
                {
                    CustomerName.Content = orders[i].CustomerName;
                    OrderDeadline.Content = orders[i].Deadline;
                        
                    for (int j = 0; j < orders[i].product1List.Count; j++)
                    {
                        foreach (Product machine in Controller.getRequiredMachineFromProductDB(Controller.getOrdersFromDatabaseToOrderList()[i].product1List[j].Name))
                        {
                            for (int k = 0; k < machine.machineList.Count; k++)
                            {
                                if (Controller.getMachineTimes()[k].Name.Substring(0, 3) == machine.machineList[k].Name.Substring(0, 3))
                                {
                                    if (Controller.getMachineTimes()[k].StartDate < Controller.orderList[i].Deadline)
                                    {
                                        Pro1M1.Minimum = 0;
                                    }
                                }
                                if (Controller.getMachineTimes()[k].StartDate > Controller.orderList[i].Deadline)
                                {
                                    TimeSpan span = Controller.orderList[i].Deadline - Controller.getMachineTimes()[k].StartDate;
                                    Pro1M1.Maximum = span.TotalDays;
                                }
                                TimeSpan workTime = Controller.getMachineTimes()[k].StartDate - Controller.getMachineTimes()[k].EndDate;
                                if (Controller.getMachineTimes()[k - 1].EndDate <= Controller.getMachineTimes()[k].EndDate)
                                {
                                    workTime = Controller.getMachineTimes()[k].EndDate - Controller.getMachineTimes()[k - 1].EndDate;
                                }
                                Pro1M1.Value = workTime.TotalDays;
                                //Pro1M1.Minimum = Convert.ToDouble(MachineEndTime.machineList[k].StartDate.ToOADate());
                                //MachineProgess = Convert.ToDouble(MachineProgess + MachineEndTime.machineList[k].EndDate.ToOADate());
                            }
                        }
                        for (int t = 0; t < Controller.getOrdersFromDatabaseToOrderList()[i].product2List.Count; t++)
                        {
                            foreach (Product machine in Controller.getRequiredMachineFromProductDB(Controller.getOrdersFromDatabaseToOrderList()[i].product2List[t].Name))
                            {
                                for (int k = 0; k < machine.machineList.Count; k++)
                                {
                                    if (Controller.getMachineTimes()[k].Name.Substring(0, 3) == machine.machineList[k].Name.Substring(0, 3))
                                    {
                                        if (Controller.getMachineTimes()[k].StartDate < Controller.orderList[i].Deadline)
                                        {
                                            Pro1M1.Minimum = 0;
                                        }
                                    }
                                    if (Controller.getMachineTimes()[k].StartDate > Controller.orderList[i].Deadline)
                                    {
                                        TimeSpan span = Controller.orderList[i].Deadline - Controller.getMachineTimes()[k].StartDate;
                                        Pro1M1.Maximum = span.TotalDays;
                                    }
                                    TimeSpan workTime = Controller.getMachineTimes()[k].StartDate - Controller.getMachineTimes()[k].EndDate;
                                    if (Controller.getMachineTimes()[k - 1].EndDate <= Controller.getMachineTimes()[k].EndDate)
                                    {
                                        workTime = Controller.getMachineTimes()[k].EndDate - Controller.getMachineTimes()[k - 1].EndDate;
                                    }
                                    Pro1M1.Value = workTime.TotalDays;
                                    //Pro1M1.Minimum = Convert.ToDouble(MachineEndTime.machineList[k].StartDate.ToOADate());
                                    //MachineProgess = Convert.ToDouble(MachineProgess + MachineEndTime.machineList[k].EndDate.ToOADate());
                                }
                            }
                        }
                    }
                }
            }
        }
        private void OrderSelected_DropDownOpened (object sender, EventArgs e)
        {
            if (OrderSelected.Items.Count == 0)
            {
                foreach (Order order in Controller.getOrdersFromDatabaseToOrderList())
                {
                    if (order.Confirm == 0)
                    {
                        OrderSelected.Items.Add(order.OrderName);
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            menuPlanlægger = new MainMenuProduktionsplanlægger();
            menuPlanlægger.Show();
            Close();
        }

        private void Pro1M1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }

    }
}
