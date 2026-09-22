namespace MauiApp1;

public partial class PickerImageGridPage : ContentPage
{
	Grid gr4x1, gr3x3;
	Picker picker;
	Image img;
	Switch s_pilt, s_grid;
	Random rnd = new Random();
	public PickerImageGridPage()
	{
		gr4x1 = new Grid
		{
			RowDefinitions =
			{
				new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
				new RowDefinition {Height = new GridLength(3, GridUnitType.Star)},
				new RowDefinition {Height = new GridLength(3, GridUnitType.Star)},
			},
			ColumnDefinitions =
			{
				new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
				new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
			},
		};

		picker = new Picker
		{
			Title = "Vali pilt",
			ItemsSource = new List<string> { "Pilt 1", "Pilt 2", "Pilt 3" },
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.Center
		};
		picker.SelectedIndexChanged += Piltide_valik;
		img = new Image
		{
			Source = "dotnet_bot.png",
			HorizontalOptions = LayoutOptions.Center,
		};
	}
}