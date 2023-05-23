namespace Chess
{
    public class Pawn : Piece
    {
        public Pawn(Player player, Square initialSquare) : base(player, initialSquare)
        {
        }

        private bool isFirstMove = true;

        public override void Attack(Square targetSquare)
        {
            base.Attack(targetSquare);
            isFirstMove = false;
        }

        public override void MoveTo(Square newSquare)
        {
            base.MoveTo(newSquare);
            isFirstMove = false;
        }

        public override bool CanAttack(Square newSquare)
        {
            if (Square == null) throw new Exception("Cannot attack with piece that is off the board");
            if (newSquare.IsFree) return false; // Cannot attack empty square

            int rowDiff = newSquare.Row - Square.Row;
            int colDiff = newSquare.Col - Square.Col;

            if (rowDiff != Player.Direction) return false;

            if (colDiff == -1 || colDiff == 1) return true;

            return false;
        }

        public override bool CanMoveTo(Square newSquare)
        {
            if (Square == null) throw new Exception("Cannot move piece that is off the board");

            int rowDiff = newSquare.Row - Square.Row;
            int colDiff = newSquare.Col - Square.Col;

            if (colDiff != 0) return false;
            if (rowDiff == Player.Direction) return true;
            if (isFirstMove && rowDiff == 2 * Player.Direction) return true;

            return false;
        }

        public override string ToString()
        {
            if (Player.Colour == Colour.White) 
                return "P";
            else return "p";
        }
    }
}