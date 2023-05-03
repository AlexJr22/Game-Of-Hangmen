using Game_Of_Hangmen.GameLogic;

Console.Clear();

List<string> ListOfWords = new List<string>();
var Game = new GameHangmen();

ListOfWords.Add("MINECRAFT");
ListOfWords.Add("LEAGUE OF LEGENDS");
ListOfWords.Add("DOTA 2");
ListOfWords.Add("HOLLOW KNIGHT");
ListOfWords.Add("DARK SOULS");
ListOfWords.Add("ELDEN RING");
ListOfWords.Add("BLOODBORNE");
ListOfWords.Add("DEAD CELLS");

Game.UseListOfWords(ListOfWords);

Game.Start();
