using Snakes_And_Ladder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakes_And_Ladder
{
    internal class SnakesAndLaddersDemo
    {
        public static void Main()
        {
            var boardEntities = new List<BoardEntity>
            {
                new Snake(17, 7),
                new Snake(54, 34),
                new Snake(62, 19),
                new Snake(98, 79),
                new Ladder(3, 38),
                new Ladder(24, 33),
                new Ladder(42, 93),
                new Ladder(72, 84)
            };

            var players = new List<Player>
            {
                new Player("John"),
                new Player("Doe")
            };

            var game = new Game.Builder()
                .SetBoard(new Board(boardEntities))
                .SetDie(new Die())
                .SetPlayers(players)
                .Build();

            game.Play();
        }
    }
}
