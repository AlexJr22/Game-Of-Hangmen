using Game_Of_Hangmen.Controls;

namespace Game_Of_Hangmen.GameLogic;

public class GameHangmen
{
    // Class responsible for containing the game logic
    protected string? Word { get; set; }
    protected char[]? Characters { get; set; }

    public void start()
    {
        // the game start setting are here
    }

    public void UseListOfWord(List<string> listOfWords) => this.Word = RaffleWord(listOfWords);

    public string RaffleWord(List<string> listOfWords) // picking a random word the list
    {
        if (listOfWords is null || listOfWords.Count == 0)
            throw new ArgumentException("The wordlist cannot be empty.");

        // draw a word from the list
        var random = new Random();
        int RandonWordIndex = random.Next(listOfWords.Count);

        // ruturn word
        return listOfWords[RandonWordIndex];
    }

    protected char[] SeparateCharacters(string word) => word.ToCharArray();
}
