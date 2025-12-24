using Windows.Gaming.Preview.GamesEnumeration;

namespace MathGame.MAUI;

public partial class PreviousGames : ContentPage
{
	public PreviousGames()
	{
		InitializeComponent();
        App.GameRepository.GetAllGames();
        gameList.ItemsSource = App.GameRepository.GetAllGames();
	}

	private void OnDelete(object sender, EventArgs e)
	{
		ImageButton button = (ImageButton)sender;
		App.GameRepository.Delete((int)button.BindingContext);
		gameList.ItemsSource = App.GameRepository.GetAllGames();
    }
}