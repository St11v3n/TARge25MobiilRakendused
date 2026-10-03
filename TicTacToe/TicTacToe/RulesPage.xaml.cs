namespace TicTacToe;

public partial class RulesPage : ContentPage
{
	private GameLogic gameLogistics;
	public RulesPage(GameLogic gameLogistics)
	{
		Title = "Game rules";

		this.gameLogistics = gameLogistics;

		VerticalStackLayout layout = new VerticalStackLayout
		{
			Spacing = 20,
			VerticalOptions = LayoutOptions.Center,
			HorizontalOptions = LayoutOptions.Center
		};

		Label ruleTitle = new Label { Text = "How to play:", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center};
		Label ruleText = new Label
		{
			Text = "1. Players go choose a square in turns.\n" +
				   "2. First player can choose who starts.\n" +
				   "3. First player to fill 3 rows wins.\n" +
				   "4. If the board is fully filled, then its a draw."
		};

		Button CloseBtn = new Button
		{
			Text = "Close",
			VerticalOptions = LayoutOptions.Center,
			HorizontalOptions = LayoutOptions.Center
		};

		CloseBtn.Clicked += gameLogistics.CloseBtnClicked;

		layout.Add(ruleTitle);
		layout.Add(ruleText);
		layout.Add(CloseBtn);
		this.Content = layout;
	}
}