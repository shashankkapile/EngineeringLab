namespace Snakes_And_Ladder.Entities
{
    internal class Player
    {
        public string Name { get; set; }
        public int Position { get; set; }
        public Player(string name)
        {
            Name = name;
        }
    }
}
