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
            Controller.AddProductToTemporaryList(ProductTypeDropdown.SelectedItem.ToString(), Convert.ToInt32(Amount.Text));
            
            //if (temporayList.Count < 3) {
            //    Product product = new Product();
            //        Controller.getProductsFromDatabaseToProductList().Name = product.Name;
            //        Controller.getProductsFromDatabaseToProductList()[i].Amount = product.Amount;
            //    temporayList.Add(product);
            }

        private void SubmitBt_Click(object sender, RoutedEventArgs e) {

        }
        }  


    }

