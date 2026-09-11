namespace Valgusfoor;

public partial class ValgusfoorPage : ContentPage
{
	bool IsTrafficLightOn = false; //This helps determine whether the traffic light is onn or off.

    string currentActiveLight = "None";  //This helps to understand, what singular light is currently on.
	
	public ValgusfoorPage() //A start of a constructor.
	{
		InitializeComponent(); //This helps to build a connection between this C# file and the visual stuff thats been put in the normal XAML file.
		SetupTapGestures(); //Used so that when clicked on the circual shapes, then a code gets executed.
    }

    private void SetupTapGestures() //This method demonstrates how the light cricles react when they are clicked on.
    {
        Redlight.GestureRecognizers.Add(new TapGestureRecognizer //Adds functionality for when the red light cricle is clicked on.
        {
            Command = new Command(async () =>
            {
                if (!IsTrafficLightOn) //If the traffic light is turned off, then the text will be "Turn on traffic light.".
                {
                    CurrentStateLabel.Text = "Turn on traffic light.";
                    return;
                }

                await RunAnimation(Redlight);
                CurrentStateLabel.Text = "Stop"; //Main text changes into "Stop".

                if (currentActiveLight == "Red") //If red light circle gets clicked a second time when its already been clicked, then every light is turned on.
                {
                    ResetToAllOn();
                }
                else //If every light was on or a different light was selected, then red light is turned on and everything else is grayed out.
                {
                    currentActiveLight = "Red";
                    Redlight.BackgroundColor = Colors.Red;
                    Yellowlight.BackgroundColor = Colors.Gray;
                    Greenlight.BackgroundColor = Colors.Gray;
                }
            })
        });

        Yellowlight.GestureRecognizers.Add(new TapGestureRecognizer //Adds functionality for when yellow light circle is clicked on.
        {
            Command = new Command(async () =>
            {
                if (!IsTrafficLightOn) //If traffic light is not turned on, then the main text shall be "Turn on traffic light.".
                {
                    CurrentStateLabel.Text = "Turn on traffic light";
                    return;
                }

                await RunAnimation(Yellowlight);
                CurrentStateLabel.Text = "Get ready"; //Main text changes into "Get ready".

                
                if (currentActiveLight == "Yellow") //Click on the yellow light circle again when it was already clicked on before, then every light circle is turned on.
                {
                    ResetToAllOn();
                }
                else // If yellow light circle is clicked on when all the lights are on or other specific one is turned on, then yellow light is on and everything else is grayed out.
                {
                    currentActiveLight = "Yellow";
                    Redlight.BackgroundColor = Colors.Gray;
                    Yellowlight.BackgroundColor = Colors.Yellow;
                    Greenlight.BackgroundColor = Colors.Gray;
                }
            })
        });

        Greenlight.GestureRecognizers.Add(new TapGestureRecognizer //Adds a functionality for green light circle when its clicked.
        {
            Command = new Command(async () =>
            {
                if (!IsTrafficLightOn) //If traffic light is not turned on, then display the main text "Turn on traffic light.".
                {
                    CurrentStateLabel.Text = "Turn on traffic light";
                    return;
                }

                await RunAnimation(Greenlight);
                CurrentStateLabel.Text = "Drive"; //Main text changes into "Drive

                
                if (currentActiveLight == "Green") //If green light circle is clicked on again when it was already clicked on, then all the lights are turned on.
                {
                    ResetToAllOn();
                }
                else //If green light circle is clicked on when everything is turned on or other specific light is turned on, then green light circle is on and everything else is grayed out.
                {
                    currentActiveLight = "Green";
                    Redlight.BackgroundColor = Colors.Gray;
                    Yellowlight.BackgroundColor = Colors.Gray;
                    Greenlight.BackgroundColor = Colors.Green;
                }
            })
        });
    }

    private void ResetToAllOn() //This will cause a reset in which all the lights are turned on.
    {
        currentActiveLight = "None";
        CurrentStateLabel.Text = "Choose a light.";
        Redlight.BackgroundColor = Colors.Red;
        Yellowlight.BackgroundColor = Colors.Yellow;
        Greenlight.BackgroundColor = Colors.Green;
    }

    private async Task RunAnimation(BoxView light) //Method responsible for changing the size and transparency of a circle.
    {
        await Task.WhenAll(
            light.ScaleToAsync(1.2, 150),
            light.FadeToAsync(0.5, 150)
        );

        await Task.WhenAll(
            light.ScaleToAsync(1.0, 150),
            light.FadeToAsync(1.0, 150)
        );
    }

    private void ClickedOn(object sender, EventArgs e) //When clicking the "On" button, traffic lights are all turned on.

	{
        IsTrafficLightOn = true;
        ResetToAllOn();
	}

	private void ClickedOff(object sender, EventArgs e) //When clicking the off button, then all the lights are turned off, grayed out.
	{
		IsTrafficLightOn = false;
        currentActiveLight = "None";
		CurrentStateLabel.Text = "Turn on Traffic Light.";

        Greenlight.BackgroundColor = Colors.Gray;
        Yellowlight.BackgroundColor = Colors.Gray;
        Redlight.BackgroundColor = Colors.Gray;

    }
}