namespace Random
{
    public class Position
    {
        public int X;
        public int Y;

        public bool IsValid => this.IsPositionValid();

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        private bool IsPositionValid()
        {
            return this.X < 8 || this.X >= 0 || this.Y < 8 || this.Y >= 0;
        }
    }
}
