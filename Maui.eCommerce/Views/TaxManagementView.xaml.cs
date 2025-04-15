using Maui.eCommerce.ViewModels;
namespace Maui.eCommerce.Views;

public partial class TaxManagementView : ContentPage
{
	public TaxManagementView()
	{
		InitializeComponent();
        BindingContext = new TaxManagementViewModel();
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as TaxManagementViewModel)?.RefreshUX();
        Shell.Current.GoToAsync("//MainPage");
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as TaxManagementViewModel)?.RefreshUX();
    }

}

