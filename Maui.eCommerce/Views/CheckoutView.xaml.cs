using Library.eCommerce.Services;
using Maui.eCommerce.ViewModels;
namespace Maui.eCommerce.Views;

public partial class CheckoutView : ContentPage
{
	public CheckoutView()
	{
		InitializeComponent();
        BindingContext = new CheckoutViewModel();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as CheckoutViewModel)?.RefreshProductList();
    }

}