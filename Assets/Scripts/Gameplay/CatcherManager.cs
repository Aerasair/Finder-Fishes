using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CatcherManager : MonoBehaviour
{
    private Level _level;
    private List<Fish> _currentFishes = new List<Fish>();
    private int _currentQuantityFishes;

    public event Action<List<Fish>> IsCollected;

    private void Start()
    {
        //will be refactor to CurrentmanagerLvl and Instanse (zinject)
        _level = FindObjectOfType<Level>();
    }

    public void Catch(Fish fish)
    {
        if (_currentFishes.Contains(fish)) return;

        if (_currentFishes.Count == 0 || _currentFishes.Where(r => r.GetType() == fish.GetComponent<Fish>().GetType()).Count() > 0)
        {
            _currentQuantityFishes++;
        }
        else
        {
            _currentQuantityFishes = 1;
            _currentFishes.Clear();
        }

        _currentFishes.Add(fish);

        IEnumerable<Fish> fishes = _level.Settings.Where(r => r.Fish.GetType() == fish.GetType() && r.Quantity == _currentQuantityFishes).Select(r => r.Fish);

        if (fishes.Count() > 0)
        {
            for (int i = 0; i < fishes.Count(); i++)
            {
                _level.DisableSelected(fish.GetComponent<Fish>());

            }

            if (IsCollected != null)
                IsCollected(_currentFishes);
            IsCollected?.Invoke(_currentFishes);
        }
    }
}
