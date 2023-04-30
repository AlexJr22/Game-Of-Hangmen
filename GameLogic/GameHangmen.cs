using Game_Of_Hangmen.DrawingControls;

namespace Game_Of_Hangmen.GameLogic;

public class GameHangmen
{
    // Class responsible for containing the game logic
    protected string Word { get; set; }
    protected char[] HiddenLetters;
    protected char[] Characters;
    protected short HealthPoints { get; set; }

    public GameHangmen()
    {
        this.Word = "";
        this.HealthPoints = 4;
        this.Characters = new char[0];
        this.HiddenLetters = new char[0];
    }

    public void Start() // the game start setting are here
    {
        Menu.DrawGallows();
        Console.WriteLine();
        this.ShowHiddenLetters();

        Console.WriteLine();
        Console.Write("Escolha uma letra: ");

        string? UserChoice = Console.ReadLine();
        char userChoice = ' ';

        try
        {
            if (UserChoice is not null)
                userChoice = UserChoice[0];
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("You have not entered any characters!");
            Console.WriteLine("you missed a point!");
            --HealthPoints;
        }
    }

    public void UseListOfWords(List<string> listOfWords)
    {
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
        // show the letters
        if (Characters.Length > 0)
            foreach (char character in Characters)
                Console.Write($"{character} ");
        else
            Console.WriteLine("I couldn't find any words, the word list is empty");
    }

    public void ShowHiddenLetters()
    {
        // show the hidden letters
        if (HiddenLetters.Length > 0)
            foreach (char character in HiddenLetters)
                Console.Write($"{character} ");
        else
            Console.WriteLine("I couldn't find any words, the word list is empty");
    }

    protected void CheckWord() { }

    protected void SetHiddenLetters()
    {
        // set the hidden letters
        HiddenLetters = new char[Characters.Length];
        for (int i = 0; i < Characters.Length; i++)
        {
            if (Characters[i] != '-')
                HiddenLetters[i] = '*';
            else
                HiddenLetters[i] = '-';
        }
    }
}
