using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random
{
    public class Move
    {
        public int StartX => StartingPosition.X;
        public int StartY => StartingPosition.Y;
        public int EndX => EndPosition.X;
        public int EndY => EndPosition.Y;

        public Position StartingPosition;
        public Position EndPosition;

        public int Score;

        public bool StartEqualsEnd => this.StartX == this.EndX && this.StartY == this.EndY;

        public bool IsInBoard => this.StartingPosition.IsValid && this.EndPosition.IsValid;

        public Move(int startX, int startY, int endX, int endY)
        {
            this.StartingPosition = new Position(startX, startY);
            this.EndPosition = new Position(endX, endY);
        }

        public Move(Position startingPosition, Position endPosition)
        {
            this.StartingPosition = startingPosition;
            this.EndPosition = endPosition;
        }

        public Move()
        {

        }

        public bool Equals(Move move)
        {
            return move.StartX == this.StartX 
                   && move.StartY == this.StartY 
                   && move.EndX == this.EndX 
                   && move.EndY == this.EndY;
        }
    }
}
