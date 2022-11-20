using UnityEngine;

public class Moveable : MonoBehaviour
{
    private PointsCollections _points;
    private Point _endPoint;

    private void Start()
    {
        _points = FindObjectOfType<PointsCollections>();
        _endPoint = _points.GetRandomPoint();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _endPoint.transform.position, Time.deltaTime * 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Point point))
        {
            if (point == _endPoint)
            {
                _endPoint = _points.GetRandomPointExecptOne(_endPoint);

                if (_endPoint.transform.position.x < transform.position.x)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                else
                {
                    transform.rotation =  Quaternion.Euler(0, 0, 0);
                }

            }
        }
    }




}
