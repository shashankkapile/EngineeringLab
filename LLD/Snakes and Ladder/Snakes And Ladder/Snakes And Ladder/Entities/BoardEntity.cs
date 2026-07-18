namespace Snakes_And_Ladder.Entities
{
    internal abstract class BoardEntity
    {
        public int Start { get; }
        public int End { get; }

        public BoardEntity(int start, int end)
        {
            Start = start;
            End = end;
        }
    }
}
