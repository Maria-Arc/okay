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

        private decimal cachedTax { get; set; }

        public TaxManagementViewModel()
        {
            cachedTax = _cartSvc.Tax;
        }

        public decimal Taxed
        {
            get => _cartSvc.Tax;
            set
            {
                if (_cartSvc.Tax != value)
                {
                    _cartSvc.Tax = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private decimal taxPercentage => Taxed / 100;

        public void Undo()
        {
            Taxed = cachedTax;
        }

        public void SaveTax()
        {
            cachedTax = Taxed;
        }

        public void RefreshUX()
        {
            NotifyPropertyChanged(nameof(Taxed));
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
