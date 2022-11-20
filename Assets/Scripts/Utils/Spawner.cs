using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _pointForSpawn;
    [SerializeField] private PointsCollections _points;

    private List<Fish> _currentFishes = new List<Fish>();

    public IEnumerable<Fish> SpawnFishes(LevelSetting[] setting)
    {
        foreach (LevelSetting item in setting)
        {
            for (int i = 0; i < item.Quantity; i++)
            {
                Fish newFish = Instantiate(item.Fish);
                newFish.transform.position = _points.GetRandomPoint().transform.position;
                _currentFishes.Add(newFish);
            }
        }
        return _currentFishes;
    }

}
