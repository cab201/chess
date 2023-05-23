namespace Chess;

public class Game {
    public Player White { get; }
    public Player Black { get; }
    public Board Board { get; }

    private Player currentPlayer;

    public Game(string side = "white") {
        Board = new Board();
        White = new Player(Colour.White, this);
        Black = new Player(Colour.Black, this);
        // White moves first
        if (side.Equals("white")) currentPlayer = White;
        else if (side.Equals("black")) currentPlayer = Black;
        else throw new ArgumentException($"Invalid side {side}");
    }

    public override string ToString() {
        return $"Game:\n{White}\n{Black}\n{Board}";
    }

    public List<Move> GetValidMoves()
    {
        List<Move> moves = new List<Move>();
        foreach (Square currentSquare in Board.Squares)
        {
            // Find pieces that can move to the current squares
            List<Piece> potentialOccupants = currentSquare.PotentialOccupants;
            foreach (Piece occupant in potentialOccupants)
            {
                if (occupant.Player == currentPlayer && occupant.Square != null)
                {
                    moves.Add(new Move(occupant.Square, currentSquare));
                }
            }

            // Find the threatening pieces to the current square
            List<Piece> threats = currentSquare.ThreateningPieces;
            foreach (Piece threat in threats)
            {
                // If the square is threatened by a piece by the current player
                // add a new move from the threatening piece to the square
                // the being threatened
                if (threat.Player == currentPlayer && threat.Square != null)
                {
                    moves.Add(new Attack(threat.Square, currentSquare));
                }
            }
        }
        return moves;
    }
}