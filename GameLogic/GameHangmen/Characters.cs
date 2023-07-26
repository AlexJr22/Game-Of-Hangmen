namespace Game_Of_Hangmen.GameLogic.GameHangmen;

public partial class GameHangmen
{
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

    private void NewHiddenLetters(char letter)
    {
        for (int index = 0; index < Characters.Length; ++index)
            if (Characters[index] == letter)
                HiddenLetters[index] = letter;
    }
}
