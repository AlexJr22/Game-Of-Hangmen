using Game_Of_Hangmen.DrawingControls;

namespace Game_Of_Hangmen.DrawingControls;

public static class Menu
{
    // this class is responsible for creating the menus
    public static void DrawGallows()
    {
        Console.SetCursorPosition(5, 0);
        DrawingTheGallows.DrawingCable();
        Console.SetCursorPosition(5, 1);
        DrawingTheGallows.DrawingChain();
        Console.SetCursorPosition(5, 2);
        DrawingTheGallows.DrawingPart();
        Console.SetCursorPosition(5, 3);
        DrawingTheGallows.DrawingPart();
        Console.SetCursorPosition(5, 4);
        DrawingTheGallows.DrawingPart();
        Console.SetCursorPosition(5, 5);
        DrawingTheGallows.DrawingPart();
        Console.SetCursorPosition(5, 6);
        DrawingTheGallows.DrawingPart();
    }
}
