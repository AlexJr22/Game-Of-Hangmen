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
        // draw the gallows and the man
        Menu.DrawGallows();
        Console.WriteLine();

        // hide letters
        this.ShowHiddenLetters();

        // waiting and checking if the user typed and hit the letter
        this.CheckLyrics();
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

    protected char[] SeparateCharacters(string word) => word.ToUpper().ToCharArray();

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

    protected void CheckWord(char[] characters, char[] hiddenLetters)
    {
        // finish this later
        bool areEqual = hiddenLetters.SequenceEqual(characters);

        if (areEqual)
        {
            Console.Clear();
            Console.WriteLine("You got all the letters right");

            Console.Write("the hidden word: ");
            this.ShowCharacters();
        }
        else
        {
            Console.Clear();
            this.Start();
        }
    }

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

    protected void CheckLyrics()
    {
        // wait for the user to type something
        Console.WriteLine();
        Console.Write("Escolha uma letra: ");

        string? UserChoice = Console.ReadLine();
        char Letter = ' ';

        // check if user typed something
        try
        {
            if (UserChoice is not null)
            {
                Letter = char.ToUpper(UserChoice[0]);
            }
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("You have not entered any characters!");
        }

        // check if the letter the user typed is in the hidden word
        if (CheckChoice(Letter))
        {
            NewHiddenLetters(Letter);

            this.CheckWord(Characters, HiddenLetters);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Ops, You misses the letter!");
            --HealthPoints;

            Thread.Sleep(500);
            Console.Clear();
            this.Start();
        }
    }

    protected bool CheckChoice(char letter)
    {
        for (int index = 0; index < Characters.Length; ++index)
        {
            if (Characters[index] == letter)
            {
                return true;
            }
        }
        return false;
    }

    protected void NewHiddenLetters(char letter)
    {
        for (int index = 0; index < Characters.Length; ++index)
        {
            if (Characters[index] == letter)
            {
                HiddenLetters[index] = letter;
            }
        }
    }

    protected bool CheckPV()
    {
        if (HealthPoints == 0)
            return true;

        return false;
    }
}
