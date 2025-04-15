using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
//using Android.Telephony;
using Library.eCommerce.Models;
using Library.eCommerce.Services;
//dropdown to select cart (CRUD for carts), +, right side updates
//button ar bottom to checkout
//model or whatev to contain shopping cart, shoppingcartservice is a list of this (like selected item)
//selectedcarts.cartItems

namespace Maui.eCommerce.ViewModels
{
    public class ItemViewModel
    {
        public Item Model { get; set; }

        public int Query { get; set; } = 1;

        //bro maybe change this (what does this dooo)
        public ICommand? AddCommand { get; set; }
        public ICommand? DeleteCommand { get; set; }
        private void DoAdd()
        {
            for (int i = 0; i < Query; i++)
            {
                ShoppingCartService.Current.AddOrUpdate(Model);
            }
        }

        private void DoDelete()
        {
            for (int i = 0; i < Query; i++)
            {
                ShoppingCartService.Current.ReturnItem(Model);
            }
        }

        void SetupCommands()
        {
            AddCommand = new Command(DoAdd);
            DeleteCommand = new Command(DoDelete);
        }

        public ItemViewModel()
        {
            Model = new Item();
            SetupCommands();
        }

        public ItemViewModel(Item model)
        {
            Model = model;
            SetupCommands();
        }

    }
}
