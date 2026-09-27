namespace TripsTrapsTrull;

public partial class RulesPage : ContentPage
{
    public RulesPage()
    {
        InitializeComponent();
    }

    private async void SuleLeht(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); 
    }
}
