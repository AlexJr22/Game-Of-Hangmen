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

    protected string RaffleWord(List<string> listOfWords) // picking a random word the list
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

    public void ShowCharacters()
    {
        if (Characters is not null)
            foreach (char character in Characters)
                Console.WriteLine(character);
        else
            Console.WriteLine("I couldn't find any words, the word list is empty");
    }
}
