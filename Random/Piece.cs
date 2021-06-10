namespace Random
{
    public class Piece
    {
        public PieceType PieceType;

        public Color Color;

        public int PieceScore;

        public Piece(PieceType pieceType, Color color = Color.None)
        {
            this.PieceType = pieceType;
            this.Color = color;

            this.PieceScore = (int) this.PieceType;
        }
    }

    public enum PieceType
    {
        King = 900,
        Queen = 90,
        Rook = 50,
        Bishop = 31,
        Knight = 30,
        Pawn = 10,
        Null = 0
    }

    public enum Color
    {
        White,
        Black,
        None
    }
}
