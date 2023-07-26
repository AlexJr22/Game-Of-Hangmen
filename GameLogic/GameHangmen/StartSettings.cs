using Game_Of_Hangmen.DrawingControls;

namespace Game_Of_Hangmen.GameLogic.GameHangmen;

public partial class GameHangmen
{
    // the game start setting are here
    public void Start()
    {
        // draw the gallows and the man
        Menu.DrawGallows();
        this.LPCounter();

        // hide letters
        this.ShowHiddenLetters();

        // waiting and checking if the user typed and hit the letter
        this.CheckLyrics();
    }
}
