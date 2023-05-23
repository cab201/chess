namespace Chess {
    public class Player {
        public int Colour { get; }
        public Army Army { get; }
        public Game Game { get; }

        public Player(int colour, Game game) {
            Colour = colour;
            Game = game;
            Army = new Army(this, Game.Board);
        }

        public Player Opponent {
            get {
                if (Game.White.Colour == this.Colour)
                    return Game.Black;
                else
                    return Game.White;
            }
        }

        public int Direction {
            get {
                return Colour == Chess.Colour.Black ? +1 : -1;
            }
        }

        public override string ToString() {
            return $"Player {Colour}";
        }
    }
}