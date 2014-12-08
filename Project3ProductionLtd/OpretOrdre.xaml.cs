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
            ProductTypeDropdown.IsEnabled = false;
            Height.IsEnabled = false;
            Width.IsEnabled = false;
            Spacing.IsEnabled = false;
            Price.IsEnabled = false;
            Instock.IsEnabled = false;
            Amount.IsEnabled = false;
            SubmitBt.IsEnabled = false;

        }

        private void CancelBt_Click(object sender, RoutedEventArgs e) {
            menuSælger = new MainMenuSælger();
            menuSælger.Show();
            Close();
        }

        private void ProductTypeDropdown_DropDownOpened(object sender, EventArgs e) {
            //for (int i = 0; i < Controller.getProductsFromDatabaseToProductList().Count; i++) {
            //    ProductTypeDropdown.Items.Add(Controller.getProductsFromDatabaseToProductList()[i].Name);
                
            if (ProductTypeDropdown.Items.Count == 0) {
                foreach (Product product in Controller.getProductsFromDatabaseToProductList()) {
                    ProductTypeDropdown.Items.Add(product.Name);
                }
            }
         }
        

        private void ProductTypeDropdown_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            
            
            foreach (Product product in Controller.getProductsFromDatabaseToProductList()) {
                if (ProductTypeDropdown.SelectedItem.Equals(product.Name)) {
                    Height.Text = Convert.ToString(product.Height);
                    Width.Text = Convert.ToString(product.Width);
                    Spacing.Text = Convert.ToString(product.Spacing);
                    Price.Text = Convert.ToString(product.Price);
                    Instock.Text = Convert.ToString(product.InStock);
                }


            }
        }

        private void Standardordre_Checked(object sender, RoutedEventArgs e) {
            ProductTypeDropdown.IsEnabled = true;
            Height.IsEnabled = false;
            Width.IsEnabled = false;
            Spacing.IsEnabled = false;
            Price.IsEnabled = false;
            Instock.IsEnabled = false;
            Amount.IsEnabled = true;
            SubmitBt.IsEnabled = true;
        }

        private void SpecielOrdre_Checked(object sender, RoutedEventArgs e) {
            ProductTypeDropdown.IsEnabled = false;
            Height.IsEnabled = true;
            Width.IsEnabled = true;
            Spacing.IsEnabled = true;
            Price.IsEnabled = false;
            Instock.IsEnabled = false;
            Amount.IsEnabled = true;
            SubmitBt.IsEnabled = true;
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e) {
            
        }

        private void SubmitBt_Click(object sender, RoutedEventArgs e) {
            Controller.NewOrderToDB(Controller.AddProductToTemporaryList());
        }



       


    }
}
