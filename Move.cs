namespace Chess
{
    /// <summary>
    /// Represent a move from some square to some other square
    /// </summary>
    public class Move
    {
        public Square From { get; }
        public Square To { get; }
        public Move(Square from, Square to)
        {
            From = from;
            To = to;
        }

        public override string ToString()
        {
            return $"({From.Row}, {From.Col}) {this.GetType().Name} ({To.Row}, {To.Col})"; 
        }
    }

    public class Attack : Move
    {
        public Attack(Square from, Square to) : base(from, to)
        {
        }
    }
}