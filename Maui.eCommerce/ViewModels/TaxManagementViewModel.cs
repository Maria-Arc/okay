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

        public TaxManagementViewModel()
        {
            _tempTaxed = _cartSvc.Tax;
        }
        

        public decimal Taxed
        {
            get => _cartSvc.Tax;
            set
            {
                if (_cartSvc.Tax != value)
                {
                    _cartSvc.Tax = value;
                    RefreshUX();
                }
            }
        }


        private decimal _tempTaxed;
        public decimal TempTaxed
        {
            get => _tempTaxed;
            set
            {
                _tempTaxed = value;
            }
        }

        public void SaveTax()
        {
            Taxed = _tempTaxed;
        }

        public void Undo()
        {
            _tempTaxed = Taxed;
        }


        public void RefreshUX()
        {
            NotifyPropertyChanged(nameof(TempTaxed));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName is null)
                throw new ArgumentNullException(nameof(propertyName));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
