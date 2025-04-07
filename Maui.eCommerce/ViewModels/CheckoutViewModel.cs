
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Library.eCommerce.Services;

namespace Maui.eCommerce.ViewModels
{
    public class CheckoutViewModel : INotifyPropertyChanged
    {
        private ShoppingCartService _cartSvc = ShoppingCartService.Current;

        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName is null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }
            PropertyChanged?.Invoke(sender: this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<ItemViewModel?> ShoppingCart
        {
            get
            {
                var temp = _cartSvc.CartItems.Where(i => i?.Quantity > 0).Select(m => new ItemViewModel(m));
                return new ObservableCollection<ItemViewModel?>(temp);
            }
        }

        public string TotalDisplay
        {
            get
            {
                return $"Total: {ShoppingCart.Select(item => (item?.Model?.Quantity ?? 0) * (item?.Model?.Product?.Price ?? 0) * 1.07M).Sum():C}";
            }//going through stuff in shopping cart (create temp list) calc the price and sums
        }
        public void RefreshProductList()
        {
            NotifyPropertyChanged(nameof(TotalDisplay));
            NotifyPropertyChanged(nameof(ShoppingCart));
        }
    }
}

