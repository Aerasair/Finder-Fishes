using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private LevelSetting[] _settings;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private string _targetText;
    [SerializeField] private int _numlvl;
    private IEnumerable<Fish> fishes;

    
    public LevelSetting[] Settings => _settings;
    public string TargetText => _targetText;
    public int Numlvl => _numlvl;


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

