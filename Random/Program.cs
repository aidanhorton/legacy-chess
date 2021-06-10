using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Random
{
	public class Program
	{
        //En-passon
		//Castling
		//Check mate, check and stalemate
		//	Enemy side doesn't see king as a threat
		//Fix 'default' moves the AI does - Changing the scoring doesn't even fix it
		//Make it so enemy player can 'take' king - so AI doesn't risk king because of high value
		//	Fix timer by making interval less and rounding the output
		//Add undo/redo
		//Add logs like in lichess.org to see previous moves
		//Add move preview - dots appear on available squares
        //Pawns getting to other side can turn into any piece
        //Check should highlight king
        //Cant see checkmate on final MiniMax depth



		public static Color CurrentColorMove = Color.White;
        public static Form1 Form;

		private static Board _board;

		public static int Difficulty = 2;

		[STAThread]
		static void Main()
		{
			_board = new Board();
			MoveChecking.Board = _board;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}

		public static bool IsValidMove(Move move)
		{
            return _board.MovePiece(move.StartX, move.StartY, move.EndX, move.EndY);
        }

		public static void AiMove()
		{
            var tmp = MiniMax(-100000, 100000, 0, true, CheckState.FirstMove);
            if (tmp.Equals(new Move(-1, -1, -1, -1)) || tmp.Equals(new Move(0, 0, 3, 3)))
            {
                Console.WriteLine("Check mate!");
                return;
            }

            ApplyMove(tmp);
        }

		private static Move MiniMax(int alpha, int beta, int depth, bool isComputerMove, CheckState previousCheckState)
		{
			depth += 1;
            var blackInCheckMate = new Move(-1, -1, -1, -1)
            {
                Score = -99999
            };
            var whiteInCheckMate = new Move(-1, -1, -1, -1)
            {
                Score = 99999
            };
            var defaultMove = new Move(0, 0, 3, 3);
            var bestMove = defaultMove;

            /*var isInCheck = CheckForCheck(Color.Black);
            if (isInCheck == CheckState.BlackCheck && previousCheckState == CheckState.BlackCheck && isComputerMove)
            {
                throw new Exception("Impossible to be enemy move and be in check for two turns");
            }

            if (isInCheck == CheckState.BlackCheck && previousCheckState == CheckState.BlackCheck && !isComputerMove)
            {
                return checkMateMove;
            }

            if (isInCheck == CheckState.BlackCheck && previousCheckState == CheckState.None && !isComputerMove)
            {
                return checkMateMove;
            }*/

            var currentCheckState = CheckForCheck();
            if (previousCheckState == CheckState.BlackCheck || previousCheckState == CheckState.BothInCheck)
            {
                if ((currentCheckState == CheckState.BlackCheck || currentCheckState == CheckState.BothInCheck) && !isComputerMove)
                {
                    // Invalid move - stayed in check.
                    return blackInCheckMate;
                }
            }
            else if (previousCheckState == CheckState.WhiteCheck || previousCheckState == CheckState.BothInCheck)
            {
                if ((currentCheckState == CheckState.WhiteCheck || currentCheckState == CheckState.WhiteCheck) && isComputerMove)
                {
                    // Invalid move - stayed in check.
                    return whiteInCheckMate;
                }
            }
            else if (previousCheckState == CheckState.None)
            {
                if ((currentCheckState == CheckState.BlackCheck || currentCheckState == CheckState.BothInCheck) && !isComputerMove)
                {
                    // Invalid move - moved into check.
                    return blackInCheckMate;
                }

                if ((currentCheckState == CheckState.WhiteCheck || currentCheckState == CheckState.BothInCheck) && isComputerMove)
                {
                    // Invalid move - moved into check.
                    return whiteInCheckMate;
                }
            }

            var score = ScoreGameState(isComputerMove);

			var moves = new List<Move>();
            
            if (depth > Difficulty * 2)
			{
                defaultMove.Score = score;
				return defaultMove;
			}

			if (isComputerMove)
            {
                for (var y = 0; y < 8; y++)
				{
					for (var x = 0; x < 8; x++)
					{
						if (_board.GetPiece(x, y).Color == Color.Black)
						{
							foreach (var m in MoveChecking.GetIntMoves(x, y))
							{
								moves.Add(m);
							}
						}
					}
				}
			}
			else
			{
                for (var y = 0; y < 8; y++)
				{
					for (var x = 0; x < 8; x++)
					{
						if (_board.GetPiece(x, y).Color == Color.White)
						{
							foreach (Move m in MoveChecking.GetIntMoves(x, y))
							{
								moves.Add(m);
							}
						}
					}
				}
			}
			
			if (moves.Count == 0)
			{
                defaultMove.Score = score;
				return defaultMove;
			}

			if (isComputerMove)
			{
                foreach (Move m in moves)
				{
					//Perform move
					Piece piece = null;
					if (_board.GetPiece(m.EndX, m.EndY) != null)
					{
						piece = _board.GetPiece(m.EndX, m.EndY);
					}
					_board.MoveAiPiece(m.StartX, m.StartY, m.EndX, m.EndY);

					var move = MiniMax(alpha, beta, depth, false, currentCheckState);

                    //Undo move
					_board.MoveAiPiece(m.EndX, m.EndY, m.StartX, m.StartY);
					if (piece != null)
					{
						_board.AddPiece(piece, m.EndX, m.EndY);
					}

                    if (move.Equals(blackInCheckMate))
                    {
                        continue;
                    }

                    if (move.Score > alpha)
					{
						alpha = move.Score;
						bestMove = m;
					}
					if (alpha >= beta)
					{
						break;
					}
				}

				bestMove.Score = alpha;
				return bestMove;
			}
			else
			{
                foreach (Move m in moves)
				{
					//Perform move
					Piece piece = null;
					if (_board.GetPiece(m.EndX, m.EndY) != null)
					{
						piece = _board.GetPiece(m.EndX, m.EndY);
					}
					_board.MoveAiPiece(m.StartX, m.StartY, m.EndX, m.EndY);

					var move = MiniMax(alpha, beta, depth, true, currentCheckState);

                    //Undo move
                    _board.MoveAiPiece(m.EndX, m.EndY, m.StartX, m.StartY);
					if (piece != null)
					{
						_board.AddPiece(piece, m.EndX, m.EndY);
					}

                    if (move.Equals(whiteInCheckMate))
                    {
                        continue;
                    }

                    if (move.Score < beta)
					{
						beta = move.Score;
						bestMove = m;
					}
					if (alpha >= beta)
					{
						break;
					}
				}
				bestMove.Score = beta;
				return bestMove;
			}
		}

		private static int ScoreGameState(bool comp)
		{
			//Score game state and check for check/checkmate

            var pieceScore = 0;
			if (comp)
			{
                for (var y = 0; y < 8; y++)
				{
					for (var x = 0; x < 8; x++)
					{
						var currentPiece = _board.GetPiece(x, y);
                        if (currentPiece.PieceType == PieceType.Null)
                        {
                            continue;
                        }

                        pieceScore = currentPiece.Color == Color.White
                            ? pieceScore - currentPiece.PieceScore
                            : pieceScore + currentPiece.PieceScore;
                    }
				}
			}
			else
			{
				for (var y = 0; y < 8; y++)
				{
					for (var x = 0; x < 8; x++)
					{
						var currentPiece = _board.GetPiece(x, y);
                        if (currentPiece.PieceType == PieceType.Null)
                        {
                            continue;
                        }

                        pieceScore = currentPiece.Color == Color.White
                            ? pieceScore + currentPiece.PieceScore
                            : pieceScore - currentPiece.PieceScore;
                    }
				}
			}

			return pieceScore;
		}

        public static CheckState CheckForCheck(Color kingColor)
        {
            for (var y = 0; y < 8; y++)
            {
                for (var x = 0; x < 8; x++)
                {
                    var currentPiece = _board.GetPiece(x, y);
                    if (currentPiece.PieceType == PieceType.Null || currentPiece.Color == kingColor)
                    {
                        continue;
                    }

                    var inCheck = MoveChecking.GetCheck(x, y);
                    if (inCheck)
                    {
                        return kingColor == Color.Black
                            ? CheckState.BlackCheck
                            : CheckState.WhiteCheck;
                    }
                }
            }

            return CheckState.None;
        }

        public static CheckState CheckForCheck()
        {
            var whiteCheck = false;
            var blackCheck = false;

            for (var y = 0; y < 8; y++)
            {
                for (var x = 0; x < 8; x++)
                {
                    var currentPiece = _board.GetPiece(x, y);
                    if (currentPiece.PieceType == PieceType.Null)
                    {
                        continue;
                    }

                    if (currentPiece.Color == Color.White && !blackCheck)
                    {
                        blackCheck = MoveChecking.GetCheck(x, y);
                    }
                    else if (currentPiece.Color == Color.Black && !whiteCheck)
                    {
                        whiteCheck = MoveChecking.GetCheck(x, y);
                    }
                }
            }

            if (blackCheck && whiteCheck)
            {
                return CheckState.BothInCheck;
            }

            if (blackCheck)
            {
                return CheckState.BlackCheck;
            }

            return whiteCheck ? CheckState.WhiteCheck : CheckState.None;
        }

        private static void ApplyMove(Move move)
		{
			_board.MoveAiPiece(move.StartX, move.StartY, move.EndX, move.EndY);

			Form.HighlightAiPieces(move);
            Form.IsComputerMove = false;
            Program.CurrentColorMove = Color.White;
        }

		public static bool IsCorrectType(int x, int y)
        {
            var currentPiece = _board.GetPiece(x, y);
            if (currentPiece.PieceType == PieceType.Null)
            {
                return false;
            }

            return CurrentColorMove == Color.White && currentPiece.Color == Color.White || CurrentColorMove == Color.Black && currentPiece.Color == Color.Black;
        }
	}

    public enum CheckState
    {
        WhiteCheck,
        BlackCheck,
        BothInCheck,
        WhiteCheckMate,
        BlackCheckMate,
        BothInCheckMate,
        FirstMove,
        None
    }
}
