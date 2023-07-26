namespace Game_Of_Hangmen.GameLogic.GameHangmen;

public partial class GameHangmen
{
    // Variables, Props
    private string Word { get; set; }
    private char[] HiddenLetters;
    private char[] Characters;
    private short HealthPoints { get; set; }
    private List<string> ListOfWords = new List<string>();
    private bool FirstRun;
}
