using System;
using UnityEngine;
using UnityEngine.UI;

public class SetLevelProperty : MonoBehaviour
{
    [SerializeField] private HeatTost _interactable;
    [SerializeField] private Text _needCountToasts;
    [SerializeField] private GameObject _plateToasts;
    private int _defaultsCountToasts = 20;
    private int _maximumCountToasts = 50;
    private int _currentlevel;
    public void SetNeedCountToasts()
    {
        _interactable.enabled = true;
        _needCountToasts.text = Convert.ToString(UnityEngine.Random.Range(_defaultsCountToasts, _maximumCountToasts));
        _plateToasts.SetActive(false);
    }
}
