public class Position
{
    private const int _maxXPosition = 4;
    private const int _maxYPosition = 4;
    public int X { get; }
    public int Y { get; }

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool IsValid()
    {
        return X >= 0 && X <= _maxXPosition && Y >= 0 && Y <= _maxYPosition;
    }
}