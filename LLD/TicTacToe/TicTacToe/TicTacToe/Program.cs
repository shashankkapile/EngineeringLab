using TicTacToe.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        var john = new Player("John", TicTacToe.Enums.Symbol.X);
        var doe = new Player("Doe", TicTacToe.Enums.Symbol.O);

        var game = new Game(john, doe, 3);

        game.MakeMove(0, 0);
        game.MakeMove(0, 1);
        game.MakeMove(0, 0);
    }
}