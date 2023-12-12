using AdventOfCode.Models;

namespace AdventOfCode;

public class GalaxyMap : CharMap
{

    public List<Coordinate> GetGalaxiesInColumn(long x)
    {
        var coordinates = new List<Coordinate>();
        foreach(var galaxy in Map)
        {
            var coord = new Coordinate(galaxy.Key);
            if (coord.X == x)
            {
                coordinates.Add(coord);
            }
        }
        return coordinates;
    }
    
    public List<Coordinate> GetGalaxiesInRow(long y)
    {
        var coordinates = new List<Coordinate>();
        foreach(var galaxy in Map)
        {
            var coord = new Coordinate(galaxy.Key);
            if (coord.Y == y)
            {
                coordinates.Add(coord);
            }
        }
        return coordinates;
    }
}
