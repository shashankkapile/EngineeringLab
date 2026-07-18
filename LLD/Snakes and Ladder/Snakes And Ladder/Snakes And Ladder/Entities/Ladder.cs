namespace Snakes_And_Ladder.Entities
{
    internal class Ladder : BoardEntity
    {
        public Ladder(int start, int end) : base(start, end)
        {
            if (start >= end) throw new ArgumentException("Invalid Ladder");
        }
    }
}
