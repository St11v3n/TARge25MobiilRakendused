

namespace Tree;

public partial class TreePage : ContentPage
{
	
	public TreePage()
	{
		InitializeComponent();
	}
    private async void OnActionClicked(object sender, EventArgs e)
    {
        if (ActionPicker.SelectedItem == null)
        {
            InfoLabel.Text = "Viga: Vali tegevus!";
            return;
        }

        string choice = ActionPicker.SelectedItem.ToString();

        uint speed = (uint)SpeedStepper.Value;
        SpeedLabel.Text = speed.ToString();

        InfoLabel.TextColor = Colors.Black;

        switch (choice)
        {
            case "Kasva":
                InfoLabel.Text = "Puu kasvab!";

                
                Random r = new Random();
                double randomGrowth = r.NextDouble() * (2.0 - 1.2) + 1.2;

               
                await Task.WhenAll(
                    Leaves.ScaleToAsync(randomGrowth, speed),
                    Body.ScaleToAsync(randomGrowth, speed)
                );
                break;

            case "Õitse":
                InfoLabel.Text = "Puu õitseb!";
               
                Leaves.BackgroundColor = Colors.Pink;
                break;

            case "Värise":
                InfoLabel.Text = "Puu väriseb tuules!";
               
                await Task.WhenAll(Leaves.TranslateToAsync(-15, 0, speed / 4), Body.TranslateToAsync(-15, 0, speed / 4));
                await Task.WhenAll(Leaves.TranslateToAsync(15, 0, speed / 4), Body.TranslateToAsync(15, 0, speed / 4));
                await Task.WhenAll(Leaves.TranslateToAsync(0, 0, speed / 4), Body.TranslateToAsync(0, 0, speed / 4));
                break;

            case "Langeta":
                
                int month= VirtualDatePicker.Date.Value.Month;
                int hour = VirtualTimePicker.Time.Value.Hours;

               
                bool onTalv = (month == 12 || month == 1 || month == 2);

                
                bool onValgeAeg = (hour >= 8 && hour < 17);

                if (!onTalv || !onValgeAeg)
                {
                    
                    InfoLabel.Text = "Pimedas ja suvel puid ei langetata!";
                    InfoLabel.TextColor = Colors.Red;
                }
                else
                {
                    InfoLabel.Text = "Puu langetatakse!";
                    
                    await Task.WhenAll(
                        Leaves.RotateToAsync(90, speed),
                        Body.RotateToAsync(90, speed)
                    );
                }
                break;

            case "Lähtesta":
                InfoLabel.Text = "Puu taastati algsesse olekusse.";
                InfoLabel.TextColor = Colors.Black;

               
                await Task.WhenAll(
                    Body.ScaleToAsync(1.0, speed),
                    Leaves.ScaleToAsync(1.0, speed),
                    Body.TranslateToAsync(0, 0, speed),
                    Leaves.TranslateToAsync(0, 0, speed),
                    Body.RotateToAsync(0, speed),
                    Leaves.RotateToAsync(0, speed)
                );

                Leaves.BackgroundColor = Colors.Green;
                OpacitySlider.Value = 1.0;
                Leaves.Opacity = 1.0;
                break;
        }
    }

    private void OnOpacitySliderChanged(object sender, ValueChangedEventArgs e)
    {
        if (Leaves != null)
        {
            Leaves.Opacity = e.NewValue;
        }
    }
}
    