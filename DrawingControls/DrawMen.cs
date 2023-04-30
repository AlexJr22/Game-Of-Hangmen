namespace Game_Of_Hangmen.DrawingControls;

public static class DrawMan
{
    // this is the stickman drawing
    //     O      -> DrawHead();
    //  >--|--<   -> DrawArms();
    //     |      -> DrawHalf();
    //   _/ \_    -> DrawLegs();

    public static void Drawing()
    {
        DrawHead();
        DrawArms();
        DrawHalf();
        DrawLegs();
    }

    public static void DrawHead() => Console.WriteLine("   O   ");

    public static void DrawArms() => Console.WriteLine(">--|--<");

    public static void DrawHalf() => Console.WriteLine("   |   ");

    public static void DrawLegs() => Console.WriteLine(" _/ \\_ ");
}
