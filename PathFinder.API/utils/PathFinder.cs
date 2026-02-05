using System.Numerics;

namespace PathFinder.API.utils;

public class PathFinder
{
    public PathFinder(PointValue[][] grid, Point start, Point end)
    {
        Grid = grid;
        Start = start;
        End = end;
    }

    public PointValue[][] Grid { get; set; }

    public Point Start { get; set; }
    public Point End { get; set; }
    public Dictionary<Point, Point> parents { get; set; } = new();
    public Queue<Point> queue { get; set; } = new();
    public List<Point> findShortestPath()
    {
        queue.Enqueue(Start);
        parents[Start] = null;

        while (queue.Count > 0)
        {
            Point current = queue.Dequeue();
            if (current.X == End.X && current.Y == End.Y)
            {
                return ReconstructPath(parents, current);
            }

            foreach (Point neighbor in getNeighbors(current))
            {
                if (!parents.ContainsKey(neighbor))
                {
                    parents[neighbor] = current;
                    queue.Enqueue(neighbor);
                }
            }
        }
        return new List<Point>();
    }

    public List<Point> ReconstructPath(Dictionary<Point, Point> parents, Point end)
    {
        List<Point> path = new List<Point>();
        Point current = end;

        while (current != null)
        {
            path.Add(current);
            current = parents[current];
        }

        path.Reverse();
        return path;

    }

    public List<Point> getNeighbors(Point current)
    {
        List<Point> neighbors = new List<Point>();
        List<Vector2> directions =
            new List<Vector2>([Vector2.One, new Vector2(1,-1), new Vector2(-1,1), new Vector2(-1,-1),new Vector2(1,0),new Vector2(-1,0),new Vector2(0,1),new Vector2(0,-1)]);
        foreach (Vector2 dir in directions)
        {
            Vector2 candidate = new Vector2(current.X + dir.X, current.Y + dir.Y);
            if (isAttainable(candidate))
            {
                neighbors.Add(new Point((int)candidate.X, (int)candidate.Y, Grid[(int)candidate.X][(int)candidate.Y]));
            }
        }

        return neighbors;
    }

    private bool isAttainable(Vector2 candidate)
    {
        if (candidate.X < 0 || candidate.X >= Grid.Length || candidate.Y < 0)
        {
            return false;
        }

        int cols = Grid[(int)candidate.X].Length;
        if (candidate.Y >= cols)
        {
            return false;
        }

        Point candidatePt = new Point((int)candidate.X, (int)candidate.Y, Grid[(int)candidate.X][(int)candidate.Y]);
        if (!candidatePt.CanTraverse())
        {
            return false;
        }

        return true;
    }
}