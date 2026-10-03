using System.Security.Cryptography.X509Certificates;

namespace TicTacToe;

public partial class StatisticsPage : ContentPage
{
	private GameLogic gameLogistics;
	public StatisticsPage(GameLogic gameLogistics)
	{
		Title = "Statistics";

		this.gameLogistics = gameLogistics;

		VerticalStackLayout statisticslayout = new VerticalStackLayout
		{
			Spacing = 20,
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.Center
		};

		Label statisticsTitle = new Label
		{
			Text = "Game statistics:"
		};

		Label statisticsText = new Label
		{
			Text = $"Player X win count: {gameLogistics.XWinsCount}\n " +
				   $"Player O win count: {gameLogistics.OWinsCount}\n" +
				   $"Draw count: {gameLogistics.DrawsCount}"
		};

		Button CloseBtn = new Button
		{
			Text = "Close",
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };

		CloseBtn.Clicked += gameLogistics.CloseBtnClicked;

		statisticslayout.Add(statisticsTitle);
		statisticslayout.Add(statisticsText);
		statisticslayout.Add(CloseBtn);

		this.Content = statisticslayout;
	}
}