namespace PathFinder.API.utils;

public class PathRequest
{
    // The 2D grid
    public PointValue[][] Grid { get; set; }
    
    // The starting coordinate
    public Point Start { get; set; }
    
    // The target coordinate
    public Point End { get; set; }
}