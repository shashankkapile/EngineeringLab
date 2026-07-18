namespace Snakes_And_Ladder.Entities
{
    internal class Die
    {
        private readonly int[] _sequence = { 3, 5, 1, 2, 6, 3, 3, 4, 2, 1 };
        private static int _sequenceNumber = 0;

        public int Roll()
        {
            _sequenceNumber++;
            return _sequence[_sequenceNumber % _sequence.Length];
        }
    }
}
