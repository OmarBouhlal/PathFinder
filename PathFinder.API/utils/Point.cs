namespace PathFinder.API.utils;

public record Point
{
    public Point(int x, int y, PointValue value)
    {
        X = x;
        Y = y;
        Value = value;
    }

    public int X { get; set; }
    public int Y { get; set; }

    public PointValue Value { get; set;}

    public Boolean CanTraverse()
    {
        return Value == PointValue.N;
    }
}