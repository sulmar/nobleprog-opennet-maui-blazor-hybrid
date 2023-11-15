using MauiClient.ViewModel;

namespace MauiClient.View;

public partial class CounterView : ContentPage
{
	public CounterView()
	{
		InitializeComponent();

		this.BindingContext = new CounterViewModel();
	}
}