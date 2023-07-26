namespace Game_Of_Hangmen.GameLogic.GameHangmen;

public partial class GameHangmen
{
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

    private bool CheckChoice(char letter)
    {
        for (int index = 0; index < Characters.Length; ++index)
            if (Characters[index] == letter)
                return true;

        return false;
    }
}
