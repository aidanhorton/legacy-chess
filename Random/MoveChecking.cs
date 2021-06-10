using System.Collections.Generic;

namespace Random
{
	public class MoveChecking
	{
		public static Board Board;

		public static bool CanMove(Move move)
        {
            var startingPiece = Board.GetPiece(move.StartX, move.StartY);
            var endPiece = Board.GetPiece(move.EndX, move.EndY);

            if (startingPiece.PieceType == PieceType.Null || move.StartEqualsEnd || startingPiece.Color != Program.CurrentColorMove
                || endPiece.PieceType == PieceType.King || startingPiece.Color == endPiece.Color)
            {
                return false;
            }

            var moves = GetMoves(move.StartX, move.StartY);
			return moves[move.EndY, move.EndX];
        }

		public static List<Move> GetIntMoves(int x, int y)
		{
			var piece = Board.GetPiece(x, y);

            var pieceColor = piece.Color;
            var enemyColor = piece.Color == Color.White
                ? Color.Black
                : Color.White;

            var moves = new List<Move>();

			if (piece.PieceType == PieceType.Bishop)
			{
				for (var j = 0; j < 4; j++)
				{
					for (var i = 1; i < 9; i++)
					{
						if (j == 0)
						{
							if (y + i > 7 || x + i > 7 || Board.GetPiece(x + i, y + i).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x + i, y + i).Color == enemyColor)
							{
								if (Board.GetPiece(x + i, y + i).PieceType != PieceType.King)
								{
									moves.Add(new Move(x, y, x + i, y + i));
								}
								break;
							}
							else
							{
								moves.Add(new Move(x, y, x + i, y + i));

							}
						}
						else if (j == 1)
						{
							if (y - i < 0 || x - i < 0 || Board.GetPiece(x - i, y - i).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x - i, y - i).Color == enemyColor)
							{
								if (Board.GetPiece(x - i, y - i).PieceType != PieceType.King)
								{
									moves.Add(new Move(x, y, x - i, y - i));
								}
								break;
							}
							else
							{
								moves.Add(new Move(x, y, x - i, y - i));
							}
						}
						else if (j == 2)
						{
							if (y + i > 7 || x - i < 0 || Board.GetPiece(x - i, y + i).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x - i, y + i).Color == enemyColor)
							{
								if (Board.GetPiece(x - i, y + i).PieceType != PieceType.King)
								{
									moves.Add(new Move(x, y, x - i, y + i));
								}
								break;
							}
							else
							{
								moves.Add(new Move(x, y, x - i, y + i));
							}
						}
						else if (j == 3)
						{
							if (y - i < 0 || x + i > 7 || Board.GetPiece(x + i, y - i).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x + i, y - i).Color == enemyColor)
							{
								if (Board.GetPiece(x + i, y - i).PieceType != PieceType.King)
								{
									moves.Add(new Move(x, y, x + i, y - i));
								}
								break;
							}
							else
							{
								moves.Add(new Move(x, y, x + i, y - i));
							}
						}
					}
				}
			}
			else if (piece.PieceType == PieceType.Queen)
			{
				for (var j = 0; j < 8; j++)
				{
					for (var i = 1; i < 9; i++)
					{
						if (j == 0)
						{
							if (x - i < 0 || Board.GetPiece(x - i, y).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x - i, y).Color == enemyColor)
							{
								if (Board.GetPiece(x - i, y).PieceType != PieceType.King)
								{
									moves.Add(new Move(x, y, x - i, y));
								}
								break;
							}
							else
							{
								moves.Add(new Move(x, y, x - i, y));
							}
						}
						else if (j == 1)
						{
							if (x + i > 7 || Board.GetPiece(x + i, y).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x + i, y).Color == enemyColor)
							{
								if (Board.GetPiece(x + i, y).PieceType != PieceType.King)
								{
									moves.Add(new Move(x, y, x + i, y));
								}
								break;
							}
							else
							{
								moves.Add(new Move(x, y, x + i, y));
							}
						}
						else if (j == 2)
						{
							if (y - i < 0 || Board.GetPiece(x, y - i).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x, y - i).Color == enemyColor)
							{
								if (Board.GetPiece(x, y - i).PieceType != PieceType.King)
								{
									moves.Add(new Move(x, y, x, y - i));
								}
								break;
							}
							else
							{
								moves.Add(new Move(x, y, x, y - i));
							}
						}
						else if (j == 3)
						{
							if (y + i > 7 || Board.GetPiece(x, y + i).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x, y + i).Color == enemyColor)
							{
								if (Board.GetPiece(x, y + i).PieceType != PieceType.King)
								{
									moves.Add(new Move(x, y, x, y + i));
								}
								break;
							}
							else
							{
								moves.Add(new Move(x, y, x, y + i));
							}
						}
						else if (j == 4)
						{
							if (y + i > 7 || x + i > 7 || Board.GetPiece(x + i, y + i).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x + i, y + i).Color == enemyColor)
							{
								if (Board.GetPiece(x + i, y + i).PieceType != PieceType.King)
								{
									moves.Add(new Move(x, y, x + i, y + i));
								}
								break;
							}
							else
							{
								moves.Add(new Move(x, y, x + i, y + i));
							}
						}
						else if (j == 5)
						{
							if (y - i < 0 || x - i < 0 || Board.GetPiece(x - i, y - i).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x - i, y - i).Color == enemyColor)
							{
								if (Board.GetPiece(x - i, y - i).PieceType != PieceType.King)
								{
									moves.Add(new Move(x, y, x - i, y - i));
								}
								break;
							}
							else
							{
								moves.Add(new Move(x, y, x - i, y - i));
							}
						}
						else if (j == 6)
						{
							if (y + i > 7 || x - i < 0 || Board.GetPiece(x - i, y + i).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x - i, y + i).Color == enemyColor)
							{
								if (Board.GetPiece(x - i, y + i).PieceType != PieceType.King)
								{
									moves.Add(new Move(x, y, x - i, y + i));
								}
								break;
							}
							else
							{
								moves.Add(new Move(x, y, x - i, y + i));
							}
						}
						else if (j == 7)
						{
							if (y - i < 0 || x + i > 7 || Board.GetPiece(x + i, y - i).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x + i, y - i).Color == enemyColor)
							{
								if (Board.GetPiece(x + i, y - i).PieceType != PieceType.King)
								{
									moves.Add(new Move(x, y, x + i, y - i));
								}
								break;
							}
							else
							{
								moves.Add(new Move(x, y, x + i, y - i));
							}
						}
					}
				}
			}
			else if (piece.PieceType == PieceType.Rook)
			{
				for (var j = 0; j < 4; j++)
				{
					for (var i = 1; i < 9; i++)
					{
						if (j == 0)
						{
							if (x - i < 0 || Board.GetPiece(x - i, y).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x - i, y).Color == enemyColor)
							{
								if (Board.GetPiece(x - i, y).PieceType != PieceType.King)
								{
									moves.Add(new Move(x, y, x - i, y));
								}
								break;
							}
							else
							{
								moves.Add(new Move(x, y, x - i, y));
							}
						}
						else if (j == 1)
						{
							if (x + i > 7 || Board.GetPiece(x + i, y).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x + i, y).Color == enemyColor)
							{
								if (Board.GetPiece(x + i, y).PieceType != PieceType.King)
								{
									moves.Add(new Move(x, y, x + i, y));
								}
								break;
							}
							else
							{
								moves.Add(new Move(x, y, x + i, y));
							}
						}
						else if (j == 2)
						{
							if (y - i < 0 || Board.GetPiece(x, y - i).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x, y - i).Color == enemyColor)
							{
								if (Board.GetPiece(x, y - i).PieceType != PieceType.King)
								{
									moves.Add(new Move(x, y, x, y - i));
								}
								break;
							}
							else
							{
								moves.Add(new Move(x, y, x, y - i));
							}
						}
						else if (j == 3)
						{
							if (y + i > 7 || Board.GetPiece(x, y + i).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x, y + i).Color == enemyColor)
							{
								if (Board.GetPiece(x, y + i).PieceType != PieceType.King)
								{
									moves.Add(new Move(x, y, x, y + i));
								}
								break;
							}
							else
							{
								moves.Add(new Move(x, y, x, y + i));
							}
						}
					}
				}
			}
			else if (piece.PieceType == PieceType.King)
			{
				if (y + 1 < 8 && Board.GetPiece(x, y + 1).Color != pieceColor && Board.GetPiece(x, y + 1).PieceType != PieceType.King)
				{
					moves.Add(new Move(x, y, x, y + 1));
				}
				if (y + 1 < 8 && x + 1 < 8 && Board.GetPiece(x + 1, y + 1).Color != pieceColor && Board.GetPiece(x + 1, y + 1).PieceType != PieceType.King)
				{
					moves.Add(new Move(x, y, x + 1, y + 1));
				}
				if (x + 1 < 8 && Board.GetPiece(x + 1, y).Color != pieceColor && Board.GetPiece(x + 1, y).PieceType != PieceType.King)
				{
					moves.Add(new Move(x, y, x + 1, y));
				}
				if (y - 1 >= 0 && x + 1 < 8 && Board.GetPiece(x + 1, y - 1).Color != pieceColor && Board.GetPiece(x + 1, y - 1).PieceType != PieceType.King)
				{
					moves.Add(new Move(x, y, x + 1, y - 1));
				}
				if (y - 1 >= 0 && Board.GetPiece(x, y - 1).Color != pieceColor && Board.GetPiece(x, y - 1).PieceType != PieceType.King)
				{
					moves.Add(new Move(x, y, x, y - 1));
				}
				if (y - 1 >= 0 && x - 1 >= 0 && Board.GetPiece(x - 1, y - 1).Color != pieceColor && Board.GetPiece(x - 1, y - 1).PieceType != PieceType.King)
				{
					moves.Add(new Move(x, y, x - 1, y - 1));
				}
				if (x - 1 >= 0 && Board.GetPiece(x - 1, y).Color != pieceColor && Board.GetPiece(x - 1, y).PieceType != PieceType.King)
				{
					moves.Add(new Move(x, y, x - 1, y));
				}
				if (x - 1 >= 0 && y + 1 < 8 && Board.GetPiece(x - 1, y + 1).Color != pieceColor && Board.GetPiece(x - 1, y + 1).PieceType != PieceType.King)
				{
					moves.Add(new Move(x, y, x - 1, y + 1));
				}
			}
			else if (piece.PieceType == PieceType.Knight)
			{
				if (y + 2 < 8 && x + 1 < 8 && Board.GetPiece(x + 1, y + 2).Color != pieceColor && Board.GetPiece(x + 1, y + 2).PieceType != PieceType.King)
				{
					moves.Add(new Move(x, y, x + 1, y + 2));
				}
				if (y + 2 < 8 && x - 1 >= 0 && Board.GetPiece(x - 1, y + 2).Color != pieceColor && Board.GetPiece(x - 1, y + 2).PieceType != PieceType.King)
				{
					moves.Add(new Move(x, y, x - 1, y + 2));
				}
				if (y + 1 < 8 && x - 2 >= 0 && Board.GetPiece(x - 2, y + 1).Color != pieceColor && Board.GetPiece(x - 2, y + 1).PieceType != PieceType.King)
				{
					moves.Add(new Move(x, y, x - 2, y + 1));
				}
				if (y + 1 < 8 && x + 2 < 8 && Board.GetPiece(x + 2, y + 1).Color != pieceColor && Board.GetPiece(x + 2, y + 1).PieceType != PieceType.King)
				{
					moves.Add(new Move(x, y, x + 2, y + 1));
				}
				if (y - 1 >= 0 && x + 2 < 8 && Board.GetPiece(x + 2, y - 1).Color != pieceColor && Board.GetPiece(x + 2, y - 1).PieceType != PieceType.King)
				{
					moves.Add(new Move(x, y, x + 2, y - 1));
				}
				if (y - 1 >= 0 && x - 2 >= 0 && Board.GetPiece(x - 2, y - 1).Color != pieceColor && Board.GetPiece(x - 2, y - 1).PieceType != PieceType.King)
				{
					moves.Add(new Move(x, y, x - 2, y - 1));
				}
				if (y - 2 >= 0 && x + 1 < 8 && Board.GetPiece(x + 1, y - 2).Color != pieceColor && Board.GetPiece(x + 1, y - 2).PieceType != PieceType.King)
				{
					moves.Add(new Move(x, y, x + 1, y - 2));
				}
				if (y - 2 >= 0 && x - 1 >= 0 && Board.GetPiece(x - 1, y - 2).Color != pieceColor && Board.GetPiece(x - 1, y - 2).PieceType != PieceType.King)
				{
					moves.Add(new Move(x, y, x - 1, y - 2));
				}
			}
			else if (piece.PieceType == PieceType.Pawn)
			{
				if (pieceColor == Color.White)
				{
					if (y == 6)
					{
						if (y - 2 >= 0 && Board.GetPiece(x, y - 2).PieceType == PieceType.Null && Board.GetPiece(x, y - 1).PieceType == PieceType.Null)
						{
							moves.Add(new Move(x, y, x, y - 2));
						}
					}
					if (y - 1 >= 0 && Board.GetPiece(x, y - 1).PieceType == PieceType.Null)
					{
						moves.Add(new Move(x, y, x, y - 1));
					}
					if (y - 1 >= 0 && x + 1 < 8 && Board.GetPiece(x + 1, y - 1).Color == Color.Black && Board.GetPiece(x + 1, y - 1).PieceType != PieceType.King)
					{
						moves.Add(new Move(x, y, x + 1, y - 1));
					}
					if (y - 1 >= 0 && x - 1 >= 0 && Board.GetPiece(x - 1, y - 1).Color == Color.Black && Board.GetPiece(x - 1, y - 1).PieceType != PieceType.King)
					{
						moves.Add(new Move(x, y, x - 1, y - 1));
					}
				}
				else if (pieceColor == Color.Black)
				{
					if (y == 1)
					{
						if (y + 2 < 8 && Board.GetPiece(x, y + 2).PieceType == PieceType.Null && Board.GetPiece(x, y + 1).PieceType == PieceType.Null)
						{
							moves.Add(new Move(x, y, x, y + 2));
						}
					}
					if (y + 1 < 8 && Board.GetPiece(x, y + 1).PieceType == PieceType.Null)
					{
						moves.Add(new Move(x, y, x, y + 1));
					}
					if (y + 1 < 8 && x + 1 < 8 && Board.GetPiece(x + 1, y + 1).Color == Color.White && Board.GetPiece(x + 1, y + 1).PieceType != PieceType.King)
					{
						moves.Add(new Move(x, y, x + 1, y + 1));
					}
					if (y + 1 < 8 && x - 1 >= 0 && Board.GetPiece(x - 1, y + 1).Color == Color.White && Board.GetPiece(x - 1, y + 1).PieceType != PieceType.King)
					{
						moves.Add(new Move(x, y, x - 1, y + 1));
					}
				}
			}
			return moves;
		}

		public static bool[,] GetMoves(int x, int y)
		{
			var piece = Board.GetPiece(x, y);

            var pieceColor = piece.Color;
            var enemyColor = piece.Color == Color.White
                ? Color.Black
                : Color.White;

            bool[,] moves = new bool[,]
			{
				{ false, false, false, false, false, false, false, false },
				{ false, false, false, false, false, false, false, false },
				{ false, false, false, false, false, false, false, false },
				{ false, false, false, false, false, false, false, false },
				{ false, false, false, false, false, false, false, false },
				{ false, false, false, false, false, false, false, false },
				{ false, false, false, false, false, false, false, false },
				{ false, false, false, false, false, false, false, false }
			};

			if (piece.PieceType == PieceType.Bishop)
			{
				for (var j = 0; j < 4; j++)
				{
					for (var i = 1; i < 9; i++)
					{
						if (j == 0)
						{
							if (y + i > 7 || x + i > 7 || Board.GetPiece(x + i, y + i).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x + i, y + i).Color == enemyColor)
							{
								moves[y + i, x + i] = true;
								break;
							}
							else
							{
								moves[y + i, x + i] = true;
							}
						} else if (j == 1)
						{
							if (y - i < 0 || x - i < 0 || Board.GetPiece(x - i, y - i).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x - i, y - i).Color == enemyColor)
							{
								moves[y - i, x - i] = true;
								break;
							}
							else
							{
								moves[y - i, x - i] = true;
							}
						} else if (j == 2)
						{
							if (y + i > 7 || x - i < 0 || Board.GetPiece(x - i, y + i).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x - i, y + i).Color == enemyColor)
							{
								moves[y + i, x - i] = true;
								break;
							}
							else
							{
								moves[y + i, x - i] = true;
							}
						} else if (j == 3)
						{
							if (y - i < 0 || x + i > 7 || Board.GetPiece(x + i, y - i).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x + i, y - i).Color == enemyColor)
							{
								moves[y - i, x + i] = true;
								break;
							}
							else
							{
								moves[y - i, x + i] = true;
							}
						}
					}
				}
			}
			else if (piece.PieceType == PieceType.Queen)
			{
				for (var j = 0; j < 8; j++)
				{
					for (var i = 1; i < 9; i++)
					{
						if (j == 0)
						{
							if (x - i < 0 || Board.GetPiece(x - i, y).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x - i, y).Color == enemyColor)
							{
								moves[y, x - i] = true;
								break;
							}
							else
							{
								moves[y, x - i] = true;
							}
						}
						else if (j == 1)
						{
							if (x + i > 7 || Board.GetPiece(x + i, y).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x + i, y).Color == enemyColor)
							{
								moves[y, x + i] = true;
								break;
							}
							else
							{
								moves[y, x + i] = true;
							}
						}
						else if (j == 2)
						{
							if (y - i < 0 || Board.GetPiece(x, y - i).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x, y - i).Color == enemyColor)
							{
								moves[y - i, x] = true;
								break;
							}
							else
							{
								moves[y - i, x] = true;
							}
						}
						else if (j == 3)
						{
							if (y + i > 7 || Board.GetPiece(x, y + i).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x, y + i).Color == enemyColor)
							{
								moves[y + i, x] = true;
								break;
							}
							else
							{
								moves[y + i, x] = true;
							}
						}
						else if (j == 4)
						{
							if (y + i > 7 || x + i > 7 || Board.GetPiece(x + i, y + i).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x + i, y + i).Color == enemyColor)
							{
								moves[y + i, x + i] = true;
								break;
							}
							else
							{
								moves[y + i, x + i] = true;
							}
						}
						else if (j == 5)
						{
							if (y - i < 0 || x - i < 0 || Board.GetPiece(x - i, y - i).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x - i, y - i).Color == enemyColor)
							{
								moves[y - i, x - i] = true;
								break;
							}
							else
							{
								moves[y - i, x - i] = true;
							}
						}
						else if (j == 6)
						{
							if (y + i > 7 || x - i < 0 || Board.GetPiece(x - i, y + i).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x - i, y + i).Color == enemyColor)
							{
								moves[y + i, x - i] = true;
								break;
							}
							else
							{
								moves[y + i, x - i] = true;
							}
						}
						else if (j == 7)
						{
							if (y - i < 0 || x + i > 7 || Board.GetPiece(x + i, y - i).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x + i, y - i).Color == enemyColor)
							{
								moves[y - i, x + i] = true;
								break;
							}
							else
							{
								moves[y - i, x + i] = true;
							}
						}
					}
				}
			}
			else if (piece.PieceType == PieceType.Rook)
			{
				for (var j = 0; j < 4; j++)
				{
					for (var i = 1; i < 9; i++)
					{
						if (j == 0)
						{
							if (x - i < 0 || Board.GetPiece(x - i, y).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x - i, y).Color == enemyColor)
							{
								moves[y, x - i] = true;
								break;
							}
							else
							{
								moves[y, x - i] = true;
							}
						}
						else if (j == 1)
						{
							if (x + i > 7 || Board.GetPiece(x + i, y).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x + i, y).Color == enemyColor)
							{
								moves[y, x + i] = true;
								break;
							}
							else
							{
								moves[y, x + i] = true;
							}
						}
						else if (j == 2)
						{
							if (y - i < 0 || Board.GetPiece(x, y - i).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x, y - i).Color == enemyColor)
							{
								moves[y - i, x] = true;
								break;
							}
							else
							{
								moves[y - i, x] = true;
							}
						}
						else if (j == 3)
						{
							if (y + i > 7 || Board.GetPiece(x, y + i).Color == pieceColor)
							{
								break;
							}
							else if (Board.GetPiece(x, y + i).Color == enemyColor)
							{
								moves[y + i, x] = true;
								break;
							}
							else
							{
								moves[y + i, x] = true;
							}
						}
					}
				}
			}
			else if (piece.PieceType == PieceType.King)
			{
				if (y + 1 < 8 && (Board.GetPiece(x, y + 1).Color != pieceColor || Board.GetPiece(x, y + 1).PieceType == PieceType.Null))
				{
					moves[y + 1, x] = true;
				}
				if (y + 1 < 8 && x + 1 < 8 && (Board.GetPiece(x + 1, y + 1).Color != pieceColor || Board.GetPiece(x + 1, y + 1).PieceType == PieceType.Null))
				{
					moves[y + 1, x + 1] = true;
				}
				if (x + 1 < 8 && (Board.GetPiece(x + 1, y).Color != pieceColor || Board.GetPiece(x + 1, y).PieceType == PieceType.Null))
				{
					moves[y, x + 1] = true;
				}
				if (y - 1 >= 0 && x + 1 < 8 && (Board.GetPiece(x + 1, y - 1).Color != pieceColor || Board.GetPiece(x + 1, y - 1).PieceType == PieceType.Null))
				{
					moves[y - 1, x + 1] = true;
				}
				if (y - 1 >= 0 && (Board.GetPiece(x, y - 1).Color != pieceColor || Board.GetPiece(x, y - 1).PieceType == PieceType.Null))
				{
					moves[y - 1, x] = true;
				}
				if (y - 1 >= 0 && x - 1 >= 0 && (Board.GetPiece(x - 1, y - 1).Color != pieceColor || Board.GetPiece(x - 1, y - 1).PieceType == PieceType.Null))
				{
					moves[y - 1, x - 1] = true;
				}
				if (x - 1 >= 0 && (Board.GetPiece(x - 1, y).Color != pieceColor || Board.GetPiece(x - 1, y).PieceType == PieceType.Null))
				{
					moves[y, x - 1] = true;
				}
				if (x - 1 >= 0 && y + 1 < 8 && (Board.GetPiece(x - 1, y + 1).Color != pieceColor || Board.GetPiece(x - 1, y + 1).PieceType == PieceType.Null))
				{
					moves[y + 1, x - 1] = true;
				}
			}
			else if (piece.PieceType == PieceType.Knight)
			{
				if (y + 2 < 8 && x + 1 < 8 && Board.GetPiece(x + 1, y + 2).Color != pieceColor)
				{
					moves[y + 2, x + 1] = true;
				}
				if (y + 2 < 8 && x - 1 >= 0 && Board.GetPiece(x - 1, y + 2).Color != pieceColor)
				{
					moves[y + 2, x - 1] = true;
				}
				if (y + 1 < 8 && x - 2 >= 0 && Board.GetPiece(x - 2, y + 1).Color != pieceColor)
				{
					moves[y + 1, x - 2] = true;
				}
				if (y + 1 < 8 && x + 2 < 8 && Board.GetPiece(x + 2, y + 1).Color != pieceColor)
				{
					moves[y + 1, x + 2] = true;
				}
				if (y - 1 >= 0 && x + 2 < 8 && Board.GetPiece(x + 2, y - 1).Color != pieceColor)
				{
					moves[y - 1, x + 2] = true;
				}
				if (y - 1 >= 0 && x - 2 >= 0 && Board.GetPiece(x - 2, y - 1).Color != pieceColor)
				{
					moves[y - 1, x - 2] = true;
				}
				if (y - 2 >= 0 && x + 1 < 8 && Board.GetPiece(x + 1, y - 2).Color != pieceColor)
				{
					moves[y - 2, x + 1] = true;
				}
				if (y - 2 >= 0 && x - 1 >= 0 && Board.GetPiece(x - 1, y - 2).Color != pieceColor)
				{
					moves[y - 2, x - 1] = true;
				}
			}
			else if (piece.PieceType == PieceType.Pawn)
			{
				if (pieceColor == Color.White)
				{
					if (y == 6)
					{
						if (y - 2 >= 0 && Board.GetPiece(x, y - 2).PieceType == PieceType.Null && Board.GetPiece(x, y - 1).PieceType == PieceType.Null)
						{
							moves[y - 2, x] = true;
						}
					}

					if (y - 1 >= 0 && Board.GetPiece(x, y - 1).PieceType == PieceType.Null)
					{
						moves[y - 1, x] = true;
					}

                    if (y - 1 >= 0 && x + 1 < 8 && Board.GetPiece(x + 1, y - 1).Color == Color.Black)
					{
						moves[y - 1, x + 1] = true;
					}

                    if (y - 1 >= 0 && x - 1 >= 0 && Board.GetPiece(x - 1, y - 1).Color == Color.Black)
					{
						moves[y - 1, x - 1] = true;
					}
				}
				else if (pieceColor == Color.Black)
				{
					if (y == 1)
					{
						if (y + 2 < 8 && Board.GetPiece(x, y + 2).PieceType == PieceType.Null && Board.GetPiece(x, y + 1).PieceType == PieceType.Null)
						{
							moves[y + 2, x] = true;
						}
					}

					if (y + 1 < 8 && Board.GetPiece(x, y + 1).PieceType == PieceType.Null)
					{
						moves[y + 1, x] = true;
					}

                    if (y + 1 < 8 && x + 1 < 8 && Board.GetPiece(x + 1, y + 1).Color == Color.White)
					{
						moves[y + 1, x + 1] = true;
					}

                    if (y + 1 < 8 && x - 1 >= 0 && Board.GetPiece(x - 1, y + 1).Color == Color.White)
					{
						moves[y + 1, x - 1] = true;
					}
				}
			}
			return moves;
		}

        public static bool GetCheck(int x, int y)
        {
            var piece = Board.GetPiece(x, y);

            var pieceColor = piece.Color;
            var enemyColor = piece.Color == Color.White
                ? Color.Black
                : Color.White;

            if (piece.PieceType == PieceType.Bishop)
            {
                for (var j = 0; j < 4; j++)
                {
                    for (var i = 1; i < 9; i++)
                    {
                        if (j == 0)
                        {
                            if (y + i > 7 || x + i > 7 || Board.GetPiece(x + i, y + i).Color != Color.None && Board.GetPiece(x + i, y + i).PieceType != PieceType.King)
                            {
                                break;
                            }
                            else if (Board.GetPiece(x + i, y + i).Color == enemyColor && Board.GetPiece(x + i, y + i).PieceType == PieceType.King)
                            {
                                return true;
                            }
                        }
                        else if (j == 1)
                        {
                            if (y - i < 0 || x - i < 0 || Board.GetPiece(x - i, y - i).Color != Color.None && Board.GetPiece(x - i, y - i).PieceType != PieceType.King)
                            {
                                break;
                            }
                            else if (Board.GetPiece(x - i, y - i).Color == enemyColor && Board.GetPiece(x - i, y - i).PieceType == PieceType.King)
                            {
                                return true;
                            }
                        }
                        else if (j == 2)
                        {
                            if (y + i > 7 || x - i < 0 || Board.GetPiece(x - i, y + i).Color != Color.None && Board.GetPiece(x - i, y + i).PieceType != PieceType.King)
                            {
                                break;
                            }
                            else if (Board.GetPiece(x - i, y + i).Color == enemyColor && Board.GetPiece(x - i, y + i).PieceType == PieceType.King)
                            {
                                return true;
                            }
                        }
                        else if (j == 3)
                        {
                            if (y - i < 0 || x + i > 7 || Board.GetPiece(x + i, y - i).Color != Color.None && Board.GetPiece(x + i, y - i).PieceType != PieceType.King)
                            {
                                break;
                            }
                            else if (Board.GetPiece(x + i, y - i).Color == enemyColor && Board.GetPiece(x + i, y - i).PieceType == PieceType.King)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            else if (piece.PieceType == PieceType.Queen)
            {
                for (var j = 0; j < 8; j++)
                {
                    for (var i = 1; i < 9; i++)
                    {
                        if (j == 0)
                        {
                            if (x - i < 0 || Board.GetPiece(x - i, y).Color != Color.None && Board.GetPiece(x - i, y).PieceType != PieceType.King)
                            {
                                break;
                            }
                            else if (Board.GetPiece(x - i, y).Color == enemyColor && Board.GetPiece(x - i, y).PieceType == PieceType.King)
                            {
                                return true;
                            }
                        }
                        else if (j == 1)
                        {
                            if (x + i > 7 || Board.GetPiece(x + i, y).Color != Color.None && Board.GetPiece(x + i, y).PieceType != PieceType.King)
                            {
                                break;
                            }
                            else if (Board.GetPiece(x + i, y).Color == enemyColor && Board.GetPiece(x + i, y).PieceType == PieceType.King)
                            {
                                return true;
                            }
                        }
                        else if (j == 2)
                        {
                            if (y - i < 0 || Board.GetPiece(x, y - i).Color != Color.None && Board.GetPiece(x, y - i).PieceType != PieceType.King)
                            {
                                break;
                            }
                            else if (Board.GetPiece(x, y - i).Color == enemyColor && Board.GetPiece(x, y - i).PieceType == PieceType.King)
                            {
                                return true;
                            }
                        }
                        else if (j == 3)
                        {
                            if (y + i > 7 || Board.GetPiece(x, y + i).Color != Color.None && Board.GetPiece(x, y + i).PieceType != PieceType.King)
                            {
                                break;
                            }
                            else if (Board.GetPiece(x, y + i).Color == enemyColor && Board.GetPiece(x, y + i).PieceType == PieceType.King)
                            {
                                return true;
                            }
                        }
                        else if (j == 4)
                        {
                            if (y + i > 7 || x + i > 7 || Board.GetPiece(x + i, y + i).Color != Color.None && Board.GetPiece(x + i, y + i).PieceType != PieceType.King)
                            {
                                break;
                            }
                            else if (Board.GetPiece(x + i, y + i).Color == enemyColor && Board.GetPiece(x + i, y + i).PieceType == PieceType.King)
                            {
                                return true;
                            }
                        }
                        else if (j == 5)
                        {
                            if (y - i < 0 || x - i < 0 || Board.GetPiece(x - i, y - i).Color != Color.None && Board.GetPiece(x - i, y - i).PieceType != PieceType.King)
                            {
                                break;
                            }
                            else if (Board.GetPiece(x - i, y - i).Color == enemyColor && Board.GetPiece(x - i, y - i).PieceType == PieceType.King)
                            {
                                return true;
                            }
                        }
                        else if (j == 6)
                        {
                            if (y + i > 7 || x - i < 0 || Board.GetPiece(x - i, y + i).Color != Color.None && Board.GetPiece(x - i, y + i).PieceType != PieceType.King)
                            {
                                break;
                            }
                            else if (Board.GetPiece(x - i, y + i).Color == enemyColor && Board.GetPiece(x - i, y + i).PieceType == PieceType.King)
                            {
                                return true;
                            }
                        }
                        else if (j == 7)
                        {
                            if (y - i < 0 || x + i > 7 || Board.GetPiece(x + i, y - i).Color != Color.None && Board.GetPiece(x + i, y - i).PieceType != PieceType.King)
                            {
                                break;
                            }
                            else if (Board.GetPiece(x + i, y - i).Color == enemyColor && Board.GetPiece(x + i, y - i).PieceType == PieceType.King)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            else if (piece.PieceType == PieceType.Rook)
            {
                for (var j = 0; j < 4; j++)
                {
                    for (var i = 1; i < 9; i++)
                    {
                        if (j == 0)
                        {
                            if (x - i < 0 || Board.GetPiece(x - i, y).Color != Color.None && Board.GetPiece(x - i, y).PieceType != PieceType.King)
                            {
                                break;
                            }
                            else if (Board.GetPiece(x - i, y).Color == enemyColor && Board.GetPiece(x - i, y).PieceType == PieceType.King)
                            {
                                return true;
                            }
                        }
                        else if (j == 1)
                        {
                            if (x + i > 7 || Board.GetPiece(x + i, y).Color != Color.None && Board.GetPiece(x + i, y).PieceType != PieceType.King)
                            {
                                break;
                            }
                            else if (Board.GetPiece(x + i, y).Color == enemyColor && Board.GetPiece(x + i, y).PieceType == PieceType.King)
                            {
                                return true;
                            }
                        }
                        else if (j == 2)
                        {
                            if (y - i < 0 || Board.GetPiece(x, y - i).Color != Color.None && Board.GetPiece(x, y - i).PieceType != PieceType.King)
                            {
                                break;
                            }
                            else if (Board.GetPiece(x, y - i).Color == enemyColor && Board.GetPiece(x, y - i).PieceType == PieceType.King)
                            {
                                return true;
                            }
                        }
                        else if (j == 3)
                        {
                            if (y + i > 7 || Board.GetPiece(x, y + i).Color != Color.None && Board.GetPiece(x, y + i).PieceType != PieceType.King)
                            {
                                break;
                            }
                            else if (Board.GetPiece(x, y + i).Color == enemyColor && Board.GetPiece(x, y + i).PieceType == PieceType.King)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            else if (piece.PieceType == PieceType.Knight)
            {
                if (y + 2 < 8 && x + 1 < 8 && Board.GetPiece(x + 1, y + 2).Color == enemyColor && Board.GetPiece(x + 1, y + 2).PieceType == PieceType.King)
                {
                    return true;
                }
                if (y + 2 < 8 && x - 1 >= 0 && Board.GetPiece(x - 1, y + 2).Color == enemyColor && Board.GetPiece(x - 1, y + 2).PieceType == PieceType.King)
                {
                    return true;
                }
                if (y + 1 < 8 && x - 2 >= 0 && Board.GetPiece(x - 2, y + 1).Color == enemyColor && Board.GetPiece(x - 2, y + 1).PieceType == PieceType.King)
                {
                    return true;
                }
                if (y + 1 < 8 && x + 2 < 8 && Board.GetPiece(x + 2, y + 1).Color == enemyColor && Board.GetPiece(x + 2, y + 1).PieceType == PieceType.King)
                {
                    return true;
                }
                if (y - 1 >= 0 && x + 2 < 8 && Board.GetPiece(x + 2, y - 1).Color == enemyColor && Board.GetPiece(x + 2, y - 1).PieceType == PieceType.King)
                {
                    return true;
                }
                if (y - 1 >= 0 && x - 2 >= 0 && Board.GetPiece(x - 2, y - 1).Color == enemyColor && Board.GetPiece(x - 2, y - 1).PieceType == PieceType.King)
                {
                    return true;
                }
                if (y - 2 >= 0 && x + 1 < 8 && Board.GetPiece(x + 1, y - 2).Color == enemyColor && Board.GetPiece(x + 1, y - 2).PieceType == PieceType.King)
                {
                    return true;
                }
                if (y - 2 >= 0 && x - 1 >= 0 && Board.GetPiece(x - 1, y - 2).Color == enemyColor && Board.GetPiece(x - 1, y - 2).PieceType == PieceType.King)
                {
                    return true;
                }
            }
            else if (piece.PieceType == PieceType.Pawn)
            {
                if (pieceColor == Color.White)
                {
                    if (y - 1 >= 0 && x + 1 < 8 && Board.GetPiece(x + 1, y - 1).Color == Color.Black && Board.GetPiece(x + 1, y - 1).PieceType == PieceType.King)
                    {
                        return true;
                    }

                    if (y - 1 >= 0 && x - 1 >= 0 && Board.GetPiece(x - 1, y - 1).Color == Color.Black && Board.GetPiece(x - 1, y - 1).PieceType == PieceType.King)
                    {
                        return true;
                    }
                }
                else if (pieceColor == Color.Black)
                {
                    if (y + 1 < 8 && x + 1 < 8 && Board.GetPiece(x + 1, y + 1).Color == Color.White && Board.GetPiece(x + 1, y + 1).PieceType == PieceType.King)
                    {
                        return true;
                    }

                    if (y + 1 < 8 && x - 1 >= 0 && Board.GetPiece(x - 1, y + 1).Color == Color.White && Board.GetPiece(x - 1, y + 1).PieceType == PieceType.King)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
