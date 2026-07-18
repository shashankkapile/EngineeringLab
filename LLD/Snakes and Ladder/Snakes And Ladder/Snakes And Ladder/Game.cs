using Snakes_And_Ladder.Entities;
using Snakes_And_Ladder.Enums;
using System.Reflection;

namespace Snakes_And_Ladder
{
    internal class Game
    {
        private Board _board { get;}
        private Die _die { get; }
        private List<Player> _players { get; }
        private GameStatus _status;
        private int _currentPlayerIndex = 0;
        private Player _winner;

        private Game(Board board, Die die, List<Player> players)
        {
            _board = board;
            _die = die;
            _players = players;
            _status = GameStatus.InProgress;
        }

        public void Play()
        {
            if (_status != GameStatus.InProgress) 
                throw new InvalidOperationException("Game over");

            int count = 0;
            int dieValue = 0;
            do
            {
                dieValue = _die.Roll();
                count++;
            } while (dieValue == 6 && count<3);

            if (count == 3 && dieValue == 6)
            {
                //cancel move
                _currentPlayerIndex = (_currentPlayerIndex+1)%_players.Count;
                return;
            }

            var currentPlayer = _players[_currentPlayerIndex];
            var finalPosition = currentPlayer.Position + _board.GetNextPosition(dieValue);

            if(finalPosition == 100)
            {
                //found winnner
                _winner = currentPlayer;
                _status = GameStatus.Finished;
                return;
            }
            if (finalPosition > 100)
            {
                //idk what to do
            }

            currentPlayer.Position = finalPosition;
        }

        public class Builder
        {
            private Board _board;
            private Die _die;
            private List<Player> _players;

            public Builder SetBoard(Board board)
            {
                _board = board;
                return this;
            }

            public Builder SetDie(Die die)
            {
                _die = die;
                return this;
            }
            public Builder SetPlayers(List<Player> players)
            {
                _players = players;
                return this;
            }

            public Game Build()
            {
                return new Game(_board, _die, _players);
            }
        }
    }
}
