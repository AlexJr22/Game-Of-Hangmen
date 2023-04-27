namespace Game_Of_Hangmen.Controls;

public static class DrawMen
{
    // this is the stickman drawing
    //     O      -> DrawHead();
    //  >--|--<   -> DrawArms();
    //     |      -> DrawHalf();
    //   _/ \_    -> DrawLegs();

    public static void Drawing()
    {
        Console.WriteLine(
            """
this is the stickman drawing 
		   O   
		>--|--<
		   |
		 _/ \_ 
"""
        );
    }
}
