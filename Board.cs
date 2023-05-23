namespace Chess {
    public class Board {
        public const int Size = 8;

        private Square[] squares = new Square[Size * Size];
        
        public Square[] Squares {
            get {
                return squares;
            }
        }

        public Board()
        {
            for(int row = 0; row < Size; row++) {
                for (int col = 0; col < Size; col++) {
                    Square newSquare = new Square(this, row, col);
                    Set(row, col, newSquare);
                }
            }
        }

        private void Set(int row, int col, Square newSquare) {
            if (row < 0 || row >= Size || col < 0 || col >= Size) throw new ArgumentException();
            squares[row * Size + col] = newSquare;
        }

        public Square ? Get( int row, int col) {
            if (row < 0 || row >= Size || col < 0 || col >= Size) return null;
            return squares[row * Size + col];
        }

        public override string ToString() {
            //return $"Board:\n{string.Join<Square>("\n", squares)}";
            string result = "";
            for (int rowIndex = 0; rowIndex < Size; rowIndex++)
            {
                // Go through each item in a row
                // and add them
                for (int columnIndex = 0; columnIndex < Size; columnIndex++)
                {
                    result += Get(rowIndex, columnIndex);
                }
                // Move on to next row
                result += "\n";
            }
            return result;
        }
    }
}