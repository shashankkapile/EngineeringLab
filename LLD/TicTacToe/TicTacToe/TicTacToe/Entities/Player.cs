using TicTacToe.Enums;

namespace TicTacToe.Entities
{
    internal class Player
    {
        private Symbol Symbol;
        private string Name;
        public Player(string name, Symbol symbol)
        {
            this.Name = name;
            this.Symbol = symbol;
        }
    }
}
