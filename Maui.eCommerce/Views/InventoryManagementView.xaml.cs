using Library.eCommerce.Services;
using Maui.eCommerce.ViewModels;
//using Microsoft.Maui.Controls.Compatibility.Platform.Android;

namespace Maui.eCommerce.Views;

public partial class InventoryManagementView : ContentPage
{
	public InventoryManagementView()
	{
		InitializeComponent();
		BindingContext = new InventoryManagementViewModel();
	}

    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as InventoryManagementViewModel)?.Delete();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//MainPage");
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Product");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as InventoryManagementViewModel)?.RefreshProductList();
    }

    private void EditClicked(object sender, EventArgs e)
    {//TODO: ?????????????
        var productId = (BindingContext as InventoryManagementViewModel)?.SelectedProduct?.Id;
        Shell.Current.GoToAsync($"//Product?productId={productId}");
    }

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as InventoryManagementViewModel)?.RefreshProductList();
    }


    //lowk just set Sort t
    private void SortToggled(object sender, ToggledEventArgs e)
    {
        if (e.Value) //true
        {
            (BindingContext as InventoryManagementViewModel)?.NameSort();
            (BindingContext as InventoryManagementViewModel)?.RefreshProductList();
        }
        else         {
            (BindingContext as InventoryManagementViewModel)?.PSort();
            (BindingContext as InventoryManagementViewModel)?.RefreshProductList();
         }   
    }
}