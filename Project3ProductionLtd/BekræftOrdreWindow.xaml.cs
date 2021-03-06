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
        //GUI og Kode af Thomas
        MainMenuProduktionsplanlægger menuPlanlægger;
        public BekræftOrdreWindow()
        {
            Controller.getOrdersFromDatabaseToOrderList();
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
            if (ConfirmOrder.Content.Equals("Confirm"))
            {
                Controller.confirmOrder(OrderSelected.SelectedItem.ToString());
                BekræftOrdreWindow bekræftet = new BekræftOrdreWindow();
                bekræftet.Show();
                Close();
            }
            else
            if (ConfirmOrder.Content.Equals("Estimate"))
            {
                for (int i = 0; i < Controller.orderList.Count; i++)
                {
                    if (OrderSelected.SelectedItem.Equals(Controller.orderList[i].OrderName))
                    {
                        Controller.newDeadline(OrderSelected.SelectedItem.ToString(), Controller.orderList[i].Deadline);
                    }
                }
                Controller.getOrdersFromDatabaseToOrderList();
                for (int i = 0; i < Controller.orderList.Count; i++)
                {
                    if (OrderSelected.SelectedItem.Equals(Controller.orderList[i].OrderName))
                    {
                        OrderDeadline.Content = Controller.orderList[i].Deadline;
                    }
                }
                
            }
        }
        private void OrderSelected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pro2.Value = 0;
            Pro1M1.Value = 0;
            for (int i = 0; i < Controller.orderList.Count; i++)
            {
                if (OrderSelected.SelectedItem.Equals(Controller.orderList[i].OrderName))
                {
                    CustomerName.Content = Controller.orderList[i].CustomerName;
                    OrderDeadline.Content = Controller.orderList[i].Deadline;
                    Product1.Content = Controller.orderList[i].OrderProductName1;
                    if (Controller.orderList[i].OrderProductName2 != "")
                    {
                        Product2.Content = Controller.orderList[i].OrderProductName2;
                    }
                    Pro1M1.Minimum = 0;
                    TimeSpan span = Controller.orderList[i].Deadline - DateTime.Now;
                    Pro1M1.Maximum = span.TotalDays;
                    string machineName = "";
                    TimeSpan workTime = DateTime.Now - DateTime.Now;
                    foreach (Product machine in Controller.getRequiredMachineFromProductDB(Controller.orderList[i].OrderProductName1))
                    {
                        for (int k = 0; k < machine.machineList.Count; k++)
                        {
                            if (k == 0)
                            {
                                workTime = machine.machineList[k].EndDate - machine.machineList[k].StartDate;
                                machineName = machine.machineList[k].Name;
                            }
                            if (k > 0)
                            {
                                TimeSpan workTime2 = machine.machineList[k].EndDate - machine.machineList[k].StartDate;
                                if (workTime <= workTime2)
                                {
                                    workTime = workTime2;
                                    machineName = machine.machineList[k].Name;
                                }
                                if (workTime >= workTime2 && machineName == machine.machineList[k].Name)
                                {
                                    workTime = workTime2;
                                    machineName = machine.machineList[k].Name;
                                }
                                
                            }
                            Pro1M1.Value = workTime.TotalDays;
                                //Pro1M1.Minimum = Convert.ToDouble(MachineEndTime.machineList[k].StartDate.ToOADate());
                                //MachineProgess = Convert.ToDouble(MachineProgess + MachineEndTime.machineList[k].EndDate.ToOADate());
                        }
                    }
                    Pro2.Minimum = 0;
                    TimeSpan span2 = Controller.orderList[i].Deadline - DateTime.Now;
                    Pro2.Maximum = span.TotalDays;
                    string machineName2 = "";
                    TimeSpan workTimefor2 = DateTime.Now - DateTime.Now;
                    foreach (Product machine in Controller.getRequiredMachineFromProductDB(Controller.orderList[i].OrderProductName2))
                    {
                        for (int k = 0; k < machine.machineList.Count; k++)
                        {
                            if (k == 0)
                            {
                                workTimefor2 = machine.machineList[k].EndDate - machine.machineList[k].StartDate;
                                machineName2 = machine.machineList[k].Name;
                            }
                            if (k > 0)
                            {
                                TimeSpan workTime2 = machine.machineList[k].EndDate - machine.machineList[k].StartDate;
                                if (workTimefor2 <= workTime2)
                                {
                                    workTimefor2 = workTime2;
                                    machineName2 = machine.machineList[k].Name;
                                }
                                if (workTimefor2 >= workTime2 && machineName == machine.machineList[k].Name)
                                {
                                    workTimefor2 = workTime2;
                                    machineName2 = machine.machineList[k].Name;
                                }
                             }
                             Pro2.Value = workTimefor2.TotalDays;
                         }
                     }
                }
            }
        }
        
        private void OrderSelected_DropDownOpened (object sender, EventArgs e)
        {
            if (OrderSelected.Items.Count == 0)
            {
                foreach (Order order in Controller.orderList)
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

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Pro2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

    }
}
