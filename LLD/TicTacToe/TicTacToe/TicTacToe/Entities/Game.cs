using TicTacToe.Enums;

namespace TicTacToe.Entities
{
    internal class Game
    {
        private int _currentPlayerIndex = 0;
        private Board _board;
        private List<Player> _players;
        private GameStatus _gameStatus;

        public Game(Player playerA, Player playerB, int size)
        {
            _board = new Board(size);
            _players = new List<Player>()
            {
                playerA,
                playerB
            };
            _gameStatus = GameStatus.InProgress;
        }

        public GameStatus GetGameStatus()
        {
            return _gameStatus;
        }

        public void MakeMove(int row, int col)
        {
            if (_gameStatus != GameStatus.InProgress) 
                throw new InvalidOperationException("Game already over");


            if (_currentPlayerIndex % 2 == 0)
            {
                _board.PlaceSymbol(row, col, Symbol.O);

                if(HasWinner(row, col, Symbol.O))
                {
                    _gameStatus = GameStatus.OWins;
                    Console.WriteLine(GameStatus.OWins+" wins");
                }
            }
            else { 
                _board.PlaceSymbol(row, col, Symbol.X);
                if (HasWinner(row, col, Symbol.X))
                {
                    _gameStatus = GameStatus.XWins;
                    Console.WriteLine(GameStatus.XWins + " wins");
                }
            }

            if (_board.IsFull())
            {
                _gameStatus = GameStatus.Draw;
                return;
            }

            _currentPlayerIndex++;
        }

        private bool HasWinner(int row, int col, Symbol symbol)
        {
            //check row

            //check col

            //check left to right diagonal

            //check right to left diagonal
            return false;
        }
    }
}
