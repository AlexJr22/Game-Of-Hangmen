namespace Game_Of_Hangmen.GameLogic.GameHangmen;

public partial class GameHangmen
{
    private void CheckLyrics()
    {
        // wait for the user to type something
        Console.WriteLine();
        Console.Write("Choice a letter: ");

        string? currentLetter = Console.ReadLine();
        char Letter = ' ';

        // check if user typed something
        try
        {
            if (currentLetter is not null)
                Letter = char.ToUpper(currentLetter[0]);
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
}
