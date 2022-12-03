using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILvlGoal : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _targetText;
    [SerializeField] private TextMeshProUGUI _numLevel;
    [SerializeField] private Level _level;

    private void Start()
    {
        _level = FindObjectOfType<Level>(); //will be refactor to zinject
        SetUpSettings();
    }

    private void SetUpSettings()
    {
        _slider.minValue = 0;
        _slider.maxValue = _level.Settings.Length;

        _targetText.text = _level.TargetText;
        _numLevel.text = $"Level: {_level.Numlvl}";//will be from player prefs lvl
    }


    public void AddStepSlider(float newValue)
    {
        _slider.DOValue(_slider.value + newValue, 1f);
    }

}
