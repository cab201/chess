namespace Chess;

public class Program {
    private static void Main(string[] args) {
        string side, inputPath, outputPath;
        side = args[0];
        if (side.Equals("name"))
        {
            Console.WriteLine("<your_bot_name_here>");
        } else
        {
            try
            {
                inputPath = args[1];
                outputPath = args[2];
            } catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("name was not given");
            }
            Console.WriteLine("Hello, Chess World! You are playing as {0}", side);

            Game game = new Game(side);

            Console.WriteLine($"Initial Game = \n{game}");

            List<Move> validMoves = game.GetValidMoves();
            foreach (Move move in validMoves)
            {
                Console.WriteLine(move);
            }
        }


        //Console.WriteLine();
        //Console.WriteLine("Threatened squares:");
        //foreach ( Square square in game.Board.Squares ) {
        //    if (square.IsThreatened) {
        //        Console.WriteLine($"{square} is threatened");
        //    }
        //}

        //Console.WriteLine();
        //Console.WriteLine("Threatening pieces:");
        //foreach ( Square square in game.Board.Squares ) {
        //    var threateningPieces = square.ThreateningPieces;

        //    foreach (var piece in threateningPieces) { 
        //        Console.WriteLine($"{square} is threatened by {piece}");
        //    }
        //}
    }
}