using EntitiesShared.POSManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Main.Forms.POSManagementForms
{
    public enum POSStateTransaction
    {
        New,
        Existing,
        Empty
    }

    public class POSState : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public POSStateTransaction Transaction { get; set; }


        private SaleTransactionModel _currentSaleTransaction;

        public SaleTransactionModel CurrentSaleTransaction
        {
            get { return _currentSaleTransaction; }
            set
            {
                _currentSaleTransaction = value;
                NotifyPropertyChanged();
            }
        }

        private List<SaleTransactionProductModel> _currentSaleTransactionProducts = new List<SaleTransactionProductModel>();

        public List<SaleTransactionProductModel> CurrentSaleTransactionProducts
        {
            get { return _currentSaleTransactionProducts; }
            set { 
                _currentSaleTransactionProducts = value;
            }
        }


        private List<SaleTransactionComboMealModel> _currentSaleTransactionComboMeals = new List<SaleTransactionComboMealModel>();

        public List<SaleTransactionComboMealModel> CurrentSaleTransactionComboMeals
        {
            get { return _currentSaleTransactionComboMeals; }
            set { _currentSaleTransactionComboMeals = value; }
        }

        public int NumberOfItems { 
            get {
                return this.CurrentSaleTransactionProducts.Count + this.CurrentSaleTransactionComboMeals.Count;
            } 
        }

        public decimal SubTotal
        {
            get
            {
                var products = this.CurrentSaleTransactionProducts;
                var comboMeals = this.CurrentSaleTransactionComboMeals;

                decimal subTotal = 0;

                foreach (var prod in products)
                {
                    subTotal += prod.Qty * prod.productCurrentPrice;
                }

                foreach (var cm in comboMeals)
                {
                    subTotal += cm.Qty * cm.ComboMealCurrentPrice;
                }

                return subTotal;
            }
        }


        public string ToStringSubTotal {
            get
            {
                return this.SubTotal.ToString("#,##0.##");
            }
        }
    }
}
