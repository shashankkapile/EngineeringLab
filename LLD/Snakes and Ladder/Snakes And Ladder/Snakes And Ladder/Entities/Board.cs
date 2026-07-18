namespace Snakes_And_Ladder.Entities
{
    internal class Board
    {
        private Dictionary<int, int> _snakesAndLadders;

        public Board(List<BoardEntity> boardEntities)
        {
            _snakesAndLadders = new Dictionary<int, int>();

            foreach (var entity in boardEntities)
            {
                _snakesAndLadders.Add(entity.Start, entity.End);
            }
        }

        public int GetNextPosition(int diceValue)
        {
            if (_snakesAndLadders.ContainsKey(diceValue))
            {
                return _snakesAndLadders[diceValue]; 
            }
            return diceValue;
        }

    }
}
