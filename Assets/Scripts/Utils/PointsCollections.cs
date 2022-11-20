using System.Linq;
using UnityEngine;

public class PointsCollections : MonoBehaviour
{
    [SerializeField] private Point[] _points;

    public Point GetRandomPoint()
    {
        return _points[Random.Range(0, _points.Length)];
    }

    public Point GetRandomPointExecptOne(Point point)
    {
        var listWithoutPoint = _points.Where(r => r.gameObject != point.gameObject);
        return listWithoutPoint.ElementAt(Random.Range(0, listWithoutPoint.Count()));
    }

}
