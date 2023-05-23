namespace Chess {
    public abstract class Piece {
        public Player Player { get; }
        public Square? Square { get; private set; }

        public Piece(Player player, Square initialSquare) {
            Player = player;
            EnterBoard(initialSquare);
        }

        public override string ToString() {
            return $"{Player.Colour} {GetType().Name} at {Square.Row}, {Square.Col}";
        }

        public void EnterBoard(Square square) {
            if (OnBoard) throw new Exception("Piece is already on the board");
            square.Place(this);
            Square = square;
        }

        public bool OnBoard {
            get {
                return Square != null;
            }
        }

        public void LeaveBoard() {
            if (Square == null) throw new ArgumentNullException("Piece cannot be removed if it is not on the board");
            Square.Remove();
        }

        public virtual void MoveTo( Square newSquare) {
            if (!CanMoveTo(newSquare)) throw new ArgumentException("Piece cannot move to designated square");
            if (newSquare.IsOccupied) throw new ArgumentException("Destination square must not be occupied");
            LeaveBoard();
            EnterBoard(newSquare);
        }

        public abstract bool CanMoveTo(Square newSquare);

        public virtual void Attack( Square targetSquare) {
            if (!CanAttack(targetSquare)) throw new ArgumentException("Piece cannot attack designated square");
            if (targetSquare.IsFree) throw new ArgumentException("Target square must be occupied");
            if (targetSquare == Square) throw new ArgumentException("Target square cannot be the same as the current square.");
            targetSquare.Occupant?.LeaveBoard();
            LeaveBoard();
            EnterBoard(targetSquare);
        }

        public abstract bool CanAttack(Square newSquare);
    }
}