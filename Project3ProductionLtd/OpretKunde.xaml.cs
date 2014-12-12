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
    /// Interaction logic for OpretKunde.xaml
    /// </summary>
    public partial class OpretKunde : Window 
    {
        //GUI af Nicolaj
        //Kode af Nicolaj og Thomas
        MainMenuSælger menuSælger;
        public OpretKunde() 
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            menuSælger = new MainMenuSælger();
            menuSælger.Show();
            Close();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if(Name.Text != "" && Address.Text !="" && Telephonenumber.Text != "")
            Controller.EnterCustomerInfomation(Name.Text, Address.Text, Telephonenumber.Text, Email.Text);
            MessageBox.Show("Customer Created");
            menuSælger = new MainMenuSælger();
        }

    }
}
