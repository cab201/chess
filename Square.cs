namespace Chess {
    public class Square {
        public Board Board { get; }
        public int Row { get; }
        public int Col { get; }

        public Square(Board board, int row, int col) {
            Board = board;
            Row = row;
            Col = col;
        }

        private Piece? occupant;

        public Piece? Occupant {
            get { return occupant; }
            private set {
                if (value == null) throw new ArgumentNullException();
                occupant = value;
            }
        }

        public bool IsFree {
            get {
                return Occupant == null;
            }
        }

        public bool IsOccupied {
            get {
                return !IsFree;
            }
        }

        public void Place(Piece piece) {
            if (IsOccupied) throw new ArgumentException("Piece cannot be placed in occupied square.");
            Occupant = piece;
        }

        public void Remove() {
            occupant = null;
        }

        public Square[] AdjacentSquares {
            get {
                // TODO implement
                return Array.Empty<Square>();
            }
        }

        public Square? Neighbour(int rowOffset, int colOffset) {
            // TODO
            return null;
        }

        // Possibly get diagonals, rows, or cols

        public bool IsThreatened {
            get {
                return ThreateningPieces.Count() != 0;
            }
        }

        /// <summary>
        /// A collection of pieces that can attack this square
        /// </summary>
        public List<Piece> ThreateningPieces {
            get {
                List<Piece> threateningPieces = new List<Piece>();
                foreach ( Square square in Board.Squares) {
                    Piece? p = square.Occupant;
                    if ( p != null && p.CanAttack(this)) {
                        threateningPieces.Add(p);
                    }
                }
                return threateningPieces;
            }
        }

        /// <summary>
        /// A collection of pieces that can move to this square
        /// </summary>
        public List<Piece> PotentialOccupants
        {
            get
            {
                List<Piece> potentialOccupants = new List<Piece>();
                foreach (Square square in Board.Squares)
                {
                    Piece? p = square.Occupant;
                    if (p != null && p.CanMoveTo(this))
                    {
                        potentialOccupants.Add(p);
                    }
                }
                return potentialOccupants;
            }
        }

        public override string ToString() {
            //if (IsFree)
            //    return $"Empty square at {Row}, {Col}";
            //else
            //    return $"{Occupant}";
            if (IsFree)
            {
                return "_";
            }
            else
            {
                return $"{Occupant}";
            }
        }
    }
}