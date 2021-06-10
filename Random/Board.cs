namespace Random
{
	public class Board
	{
        private readonly Piece[,] _board =
		{
			{ new Piece(PieceType.Rook, Color.Black), new Piece(PieceType.Knight, Color.Black), new Piece(PieceType.Bishop, Color.Black), new Piece(PieceType.King, Color.Black), new Piece(PieceType.Queen, Color.Black), new Piece(PieceType.Bishop, Color.Black), new Piece(PieceType.Knight, Color.Black), new Piece(PieceType.Rook, Color.Black) },
			{ new Piece(PieceType.Pawn, Color.Black), new Piece(PieceType.Pawn, Color.Black), new Piece(PieceType.Pawn, Color.Black), new Piece(PieceType.Pawn, Color.Black), new Piece(PieceType.Pawn, Color.Black), new Piece(PieceType.Pawn, Color.Black), new Piece(PieceType.Pawn, Color.Black), new Piece(PieceType.Pawn, Color.Black) },
			{ new Piece(PieceType.Null), new Piece(PieceType.Null), new Piece(PieceType.Null), new Piece(PieceType.Null), new Piece(PieceType.Null), new Piece(PieceType.Null), new Piece(PieceType.Null), new Piece(PieceType.Null) },
			{ new Piece(PieceType.Null), new Piece(PieceType.Null), new Piece(PieceType.Null), new Piece(PieceType.Null), new Piece(PieceType.Null), new Piece(PieceType.Null), new Piece(PieceType.Null), new Piece(PieceType.Null) },
			{ new Piece(PieceType.Null), new Piece(PieceType.Null), new Piece(PieceType.Null), new Piece(PieceType.Null), new Piece(PieceType.Null), new Piece(PieceType.Null), new Piece(PieceType.Null), new Piece(PieceType.Null) },
			{ new Piece(PieceType.Null), new Piece(PieceType.Null), new Piece(PieceType.Null), new Piece(PieceType.Null), new Piece(PieceType.Null), new Piece(PieceType.Null), new Piece(PieceType.Null), new Piece(PieceType.Null) },
			{ new Piece(PieceType.Pawn, Color.White), new Piece(PieceType.Pawn, Color.White), new Piece(PieceType.Pawn, Color.White), new Piece(PieceType.Pawn, Color.White), new Piece(PieceType.Pawn, Color.White), new Piece(PieceType.Pawn, Color.White), new Piece(PieceType.Pawn, Color.White), new Piece(PieceType.Pawn, Color.White) },
			{ new Piece(PieceType.Rook, Color.White), new Piece(PieceType.Knight, Color.White), new Piece(PieceType.Bishop, Color.White), new Piece(PieceType.King, Color.White), new Piece(PieceType.Queen, Color.White), new Piece(PieceType.Bishop, Color.White), new Piece(PieceType.Knight, Color.White), new Piece(PieceType.Rook, Color.White) }
		};

        public Piece GetPiece(int x, int y)
		{
			return this._board[y, x];
		}

		public bool MovePiece(int startX, int startY, int endX, int endY)
		{
            if (!MoveChecking.CanMove(new Move(startX, startY, endX, endY)))
            {
                return false;
            }

            var checkStateBeforeMove = Program.CheckForCheck();

            var startingPiece = this._board[startY, startX];
            var endPiece = this._board[endY, endX];

            this._board[startY, startX] = new Piece(PieceType.Null);
            this._board[endY, endX] = startingPiece;

            var checkStateAfterMove = Program.CheckForCheck();

            if ((checkStateBeforeMove == CheckState.WhiteCheck || checkStateBeforeMove == CheckState.BothInCheck) && (checkStateAfterMove == CheckState.WhiteCheck || checkStateAfterMove == CheckState.BothInCheck))
            {
                this._board[startY, startX] = startingPiece;
                this._board[endY, endX] = endPiece;

                return false;
            }

            if (checkStateBeforeMove == CheckState.None && (checkStateAfterMove == CheckState.WhiteCheck || checkStateAfterMove == CheckState.BothInCheck))
            {
                this._board[startY, startX] = startingPiece;
                this._board[endY, endX] = endPiece;

                return false;
            }

            return true;
        }

		public void MoveAiPiece(int startX, int startY, int endX, int endY)
		{
            if (this._board[endY, endX].PieceType == PieceType.Null)
            {
                var startingPiece = this._board[startY, startX];

                this._board[startY, startX] = this._board[endY, endX];
                this._board[endY, endX] = startingPiece;
            }
            else
            {
                this._board[endY, endX] = this._board[startY, startX];
                this._board[startY, startX] = new Piece(PieceType.Null);
            }
        }

		public void AddPiece(Piece piece, int x, int y)
		{
            this._board[y, x] = piece;
		}

		public void DisplayBoard()
		{
			/*int i = 0;
			foreach (string piece in Board)
			{
				i++;
				if (i % 8 == 0)
				{
					Console.WriteLine(" {0}\n-----|-----|-----|-----|-----|-----|-----|-----", piece);
				}
				else
				{
					Console.Write(" {0} |", piece);
				}
			}*/
		}
	}
}
