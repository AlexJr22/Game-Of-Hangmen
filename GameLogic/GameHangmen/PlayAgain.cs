using Game_Of_Hangmen.DrawingControls;

namespace Game_Of_Hangmen.GameLogic.GameHangmen;

public partial class GameHangmen
{
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
