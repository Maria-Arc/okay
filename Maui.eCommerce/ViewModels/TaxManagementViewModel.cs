using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Library.eCommerce.Models;
using Library.eCommerce.Services;



namespace Maui.eCommerce.ViewModels
{
    public class TaxManagementViewModel : INotifyPropertyChanged
    {

        private ShoppingCartService _cartSvc = ShoppingCartService.Current;
        public decimal Taxed { get { return _cartSvc.Tax; } set { _cartSvc.Tax = value; } }


        private decimal taxPercentage
        {
            get      
            {
                return Taxed / 100;
            }
        }

   

        public event PropertyChangedEventHandler? PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName is null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }
            PropertyChanged?.Invoke(sender: this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefreshUX()
        {

            NotifyPropertyChanged(nameof(Taxed));

        }


    }
}
