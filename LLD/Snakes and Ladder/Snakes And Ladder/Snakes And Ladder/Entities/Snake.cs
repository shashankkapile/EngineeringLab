namespace Snakes_And_Ladder.Entities
{
    internal class Snake : BoardEntity
    {
        public Snake(int start, int end) : base(start, end)
        {
            if (start <= end) throw new ArgumentException("Invalid snake");
        }

    }
}
