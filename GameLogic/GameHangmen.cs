using Game_Of_Hangmen.DrawingControls;

namespace Game_Of_Hangmen.GameLogic;

public class GameHangmen
{
    // Class responsible for containing the game logic
    private string Word { get; set; }
    private char[] HiddenLetters;
    private char[] Characters;
    private short HealthPoints { get; set; }
    private List<string> ListOfWords = new List<string>();
    private bool FirstRun;

    public GameHangmen()
    {
        this.Word = "";
        this.HealthPoints = 4;
        this.Characters = new char[0];
        this.HiddenLetters = new char[0];
        FirstRun = true;
    }

    public void Start() // the game start setting are here
    {
        // draw the gallows and the man
        Menu.DrawGallows();
        this.LPCounter();

        // hide letters
        this.ShowHiddenLetters();

        // waiting and checking if the user typed and hit the letter
        this.CheckLyrics();
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

    private char[] SeparateCharacters(string word) => word.ToUpper().ToCharArray();

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
        {
            Console.SetCursorPosition(0, 7);
            Console.WriteLine("---------------------");
            foreach (char character in HiddenLetters)
                Console.Write($"{character} ");
        }
        else
            Console.WriteLine("I couldn't find any words, the word list is empty");
    }

    private void CheckWord(char[] characters, char[] hiddenLetters)
    {
        // finish this later
        bool areEqual = hiddenLetters.SequenceEqual(characters);

        if (areEqual)
        {
            Console.Clear();
            Console.WriteLine("You got all the letters right");

            Console.Write("the hidden word: ");
            this.ShowCharacters();

            Console.WriteLine();
            this.PlayAgain();
        }
        else
        {
            Console.Clear();
            this.Start();
        }
    }

    private void SetHiddenLetters()
    {
        // set the hidden letters
        HiddenLetters = new char[Characters.Length];
        for (int index = 0; index < Characters.Length; index++)
        {
            if (Characters[index] != '-')
                HiddenLetters[index] = '*';
            else
                HiddenLetters[index] = '-';
        }
    }

    private void CheckLyrics()
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
                Letter = char.ToUpper(UserChoice[0]);
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

            if (this.CheckPV())
                this.Start();
            else
                this.GameOver();
        }
    }

    private bool CheckChoice(char letter)
    {
        for (int index = 0; index < Characters.Length; ++index)
            if (Characters[index] == letter)
                return true;

        return false;
    }

    private void NewHiddenLetters(char letter)
    {
        for (int index = 0; index < Characters.Length; ++index)
            if (Characters[index] == letter)
                HiddenLetters[index] = letter;
    }

    private bool CheckPV()
    {
        if (HealthPoints == 0)
            return false;

        return true;
    }

    private void GameOver()
    {
        Console.Clear();

        Menu.DrawGallows();
        this.LPCounter();

        Console.SetCursorPosition(0, 7);
        Console.WriteLine("---------------------");
        Console.WriteLine("You have no more LP");
        this.PlayAgain();
    }

    private void PlayAgain()
    {
        Console.WriteLine("do you want to play again? [y/n]");
        var choice = Console.ReadLine();
        if (choice is not null)
            switch (choice[0])
            {
                case 'n':
                    Console.WriteLine("see you next time");
                    System.Environment.Exit(0);
                    break;
                case 'y':
                    this.Word = "";
                    this.HealthPoints = 4;
                    this.Characters = new char[0];
                    this.HiddenLetters = new char[0];

                    this.UseListOfWords(ListOfWords);

                    Console.Clear();
                    this.Start();
                    break;
            }
        else
        {
            Console.Clear();
            Console.WriteLine("I did not understand what you typed");
            Console.WriteLine("see you next time...");
            Thread.Sleep(2000);
            System.Environment.Exit(0);
        }
    }

    private void LPCounter()
    {
        switch (HealthPoints)
        {
            case 3:
            {
                Console.SetCursorPosition(3, 2);
                DrawMan.DrawHead();
                break;
            }
            case 2:
            {
                Console.SetCursorPosition(3, 2);
                DrawMan.DrawHead();
                Console.SetCursorPosition(3, 3);
                DrawMan.DrawArms();
                break;
            }
            case 1:
            {
                Console.SetCursorPosition(3, 2);
                DrawMan.DrawHead();
                Console.SetCursorPosition(3, 3);
                DrawMan.DrawArms();
                Console.SetCursorPosition(3, 4);
                DrawMan.DrawHalf();
                break;
            }
            case 0:
            {
                Console.SetCursorPosition(3, 2);
                DrawMan.DrawHead();
                Console.SetCursorPosition(3, 3);
                DrawMan.DrawArms();
                Console.SetCursorPosition(3, 4);
                DrawMan.DrawHalf();
                Console.SetCursorPosition(3, 5);
                DrawMan.DrawLegs();
                break;
            }
        }
    }
}
