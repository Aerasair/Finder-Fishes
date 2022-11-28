using UnityEngine;
using DG.Tweening;
 
public class Moveable : MonoBehaviour
{
    private PointsCollections _points;
    private Point _endPoint;
    private Tween _rotate, _move;
    private void Start()
    {
        _points = FindObjectOfType<PointsCollections>();
        _endPoint = _points.GetRandomPoint();
        transform.DOMove(_endPoint.transform.position, 3);
        transform.DOLookAt(_endPoint.transform.position, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Point point))
        {
            if (point == _endPoint)
            {
                _endPoint = _points.GetRandomPointExecptOne(_endPoint);
                _move.Kill();
                _rotate.Kill();
                _move  =  transform.DOMove(_endPoint.transform.position, 3);
                _rotate = transform.DOLookAt(_endPoint.transform.position, 1);
            }
        }
    }




}
