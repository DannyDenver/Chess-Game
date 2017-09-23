namespace Chess.Domain.Models
{
    public class Position
    {
        public Position(int xCoordinate, int yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }

        public int XCoordinate { get; }
        public int YCoordinate { get; }
    }
}
