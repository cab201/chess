namespace Chess {
    public class Army {
        public List<Piece> Pieces {
            get {
                return pieces;
            }
        }

        private List<Piece> pieces = new List<Piece>();

        public Army(Player player, Board board) {
            Player = player;
            Board = board;

            int baseRow = player.Colour == Colour.Black ? 0 : Board.Size - 1;
            int direction = player.Direction;

            // Generate a line of pawns on the second row.
            for ( int col = 0; col < Board.Size; col++) {
                Square initialSquare = board.Get(baseRow + direction, col);
                Piece newPiece = new Pawn(player, initialSquare);
            }
        }

        public Player Player { get; }
        public Board Board { get; }
    }
}