namespace Game_Of_Hangmen.GameLogic.GameHangmen;

public partial class GameHangmen
{
    private string RaffleWord(List<string> listOfWords) // picking a random word the list
    {
        if (listOfWords is null || listOfWords.Count == 0)
            throw new ArgumentException("The wordlist cannot be empty.");

        // draw a word from the list
        var random = new Random();
        int RandonWordIndex = random.Next(listOfWords.Count);

        // ruturn word
        return listOfWords[RandonWordIndex];
    }

    public void UseListOfWords(List<string> listOfWords)
    {
        if (FirstRun)
        {
            ListOfWords.AddRange(listOfWords);
            FirstRun = false;
        }

        // adding a random word from the list to 'Word'
        this.Word = RaffleWord(listOfWords);

        // separating the letters
        if (Word.Length > 0)
            Characters = SeparateCharacters(Word.Replace(' ', '-'));
        else
            throw new ArgumentException(
                "No list was passed. Make sure you passed a list using the UseListOfWord method!"
            );

        // hiding the letters
        SetHiddenLetters();
    }
}
