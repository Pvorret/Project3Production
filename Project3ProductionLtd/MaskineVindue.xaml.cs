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
        //GUI og Kode af Phillip
        OpretArbejdsplan opretArbejdsplanMenu = new OpretArbejdsplan();
        public MaskineVindue()
        {
            InitializeComponent();
            
            
        }
           


        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ApproveBtn_Click(object sender, RoutedEventArgs e)
        {
            /*if ((StartDateTextBoxDD.Text != "" && StartDateTextBoxMM.Text != "" && StartDateTextBoxYYYY.Text != "") && (StartDateTextBoxDD.Text != "dd" && StartDateTextBoxMM.Text != "mm" && StartDateTextBoxYYYY.Text != "yyyy"))
            {
                string StartDate = StartDateTextBoxDD.Text + "-" + StartDateTextBoxMM.Text + "-" + StartDateTextBoxYYYY.Text;
                EndDateTextBoxDD.Text = Convert.ToString((Convert.ToInt32(StartDateTextBoxDD.Text) + 8));
                EndDateTextBoxMM.Text = StartDateTextBoxMM.Text;
                EndDateTextBoxYYYY.Text = StartDateTextBoxYYYY.Text;
           }*/
            MessageBox.Show("It does not do anything. At this time. Press Return to return to previous window");
        }
        private void StartDateTextBoxDD_TextChanged(object sender, TextChangedEventArgs e){ }

        private void StartDateTextBoxDD_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(StartDateTextBoxDD.Text, "[^0-9]"))
            {
                StartDateTextBoxDD.Text.Remove(StartDateTextBoxDD.Text.Length - 1);
                try
                {
                    if (StartDateTextBoxDD.Text != "dd" && StartDateTextBoxDD.Text != "d")
                    {
                        EndDateTextBoxDD.Text = Convert.ToString((Convert.ToInt32(StartDateTextBoxDD.Text) + 8));

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Only Numbers please");
                }
            }
        }

    }
}
