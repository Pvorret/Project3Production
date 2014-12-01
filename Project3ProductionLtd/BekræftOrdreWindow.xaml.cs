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
            // Use IsChecked.
            bool flag = checkBox.IsChecked.Value;

            // Assign Window Title.
            //this.Title = "IsChecked = " + flag.ToString();
            if (NewDeadline.IsChecked == true)
            {
                ConfirmOrder.Content = "Estimate";
            }
            else
                ConfirmOrder.Content = "Confirm";
        }
    }
}
