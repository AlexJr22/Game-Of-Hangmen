using Game_Of_Hangmen.DrawingControls;

namespace Game_Of_Hangmen.GameLogic.GameHangmen;

public partial class GameHangmen
{
    // Class responsible for containing the game logic
    public GameHangmen()
    {
        this.Word = "";
        this.HealthPoints = 4;
        this.Characters = new char[0];
        this.HiddenLetters = new char[0];
        FirstRun = true;
    }
}
