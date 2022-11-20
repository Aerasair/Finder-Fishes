using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private LevelSetting[] _settings;
    [SerializeField] private Spawner _spawner;

    public LevelSetting[] Settings => _settings;
    private IEnumerable<Fish> fishes;

    private void Start()
    {
        fishes = _spawner.SpawnFishes(_settings);
    }

    public void DisableSelected(Fish fish)
    {
        var type = fish.GetType();
        var list = fishes.Where(r => r.GetType() == type);

        foreach (Fish f in list)
        {
            f.gameObject.SetActive(false);
        }
    }
}

