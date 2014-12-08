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
        }
        private void OrderSelected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Controller.getMachineTimes();
            for (int i = 0; i < Controller.orderList.Count; i++)
            {
                if (OrderSelected.SelectedItem.Equals(Controller.orderList[i].OrderName))
                {
                    CustomerName.Content = Controller.orderList[i].CustomerName;
                    OrderDeadline.Content = Convert.ToDateTime(Controller.orderList[i].Deadline);

                    //if(DateTime.Now < Controller.orderList[i].Deadline)
                    //{
                    //    Pro1M1.Minimum = 0;
                    //}
                    //if(DateTime.Now > Controller.orderList[i].Deadline)
                    //{
                    //    Pro1M1.Maximum = 100;
                    //}
                    //Pro1M1.Maximum = Convert.ToDouble(Controller.orderList[i].Deadline.ToOADate());
                    
                    foreach (Product MachineEndTime in Controller.getRequiredMachineFromProductDB(Controller.orderList[i].OrderProductName1))
                    {
                        for (int k = 0; k < Controller.machineList.Count; k++)
                        {
                            if (Controller.machineList[i].Name.Substring(0, 3) == MachineEndTime.machineList[i].Name.Substring(0, 3))
                            if (Controller.machineList[k].StartDate < Controller.orderList[i].Deadline)
                            {
                                Pro1M1.Minimum = 0;
                            }
                            if (Controller.machineList[k].StartDate > Controller.orderList[i].Deadline)
                            {
                                TimeSpan span =Controller.orderList[i].Deadline -  Controller.machineList[k].StartDate;
                                Pro1M1.Maximum = span.TotalDays;
                            }
                            TimeSpan workTime = Controller.machineList[k].StartDate - Controller.machineList[k].EndDate;
                            if (Controller.machineList[k-1].EndDate <= Controller.machineList[k].EndDate)
                            {
                                workTime = Controller.machineList[k].EndDate - Controller.machineList[k-1].EndDate;
                            }
                            Pro1M1.Value = workTime.TotalDays;
                            //Pro1M1.Minimum = Convert.ToDouble(MachineEndTime.machineList[k].StartDate.ToOADate());
                            //MachineProgess = Convert.ToDouble(MachineProgess + MachineEndTime.machineList[k].EndDate.ToOADate());
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
            Pro1M1.Value = 20;
        }
    }
}
