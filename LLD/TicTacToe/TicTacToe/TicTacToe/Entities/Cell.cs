using TicTacToe.Enums;

namespace TicTacToe.Entities
{
    internal class Cell
    {
        public Symbol Symbol { get; set; }
        public Cell() {
            Symbol = Symbol.Empty;
        }

        public bool IsEmpty()
        {
            return Symbol == Symbol.Empty;
        }
    }
}
