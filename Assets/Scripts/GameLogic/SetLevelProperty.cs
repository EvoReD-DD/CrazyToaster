using System;
using UnityEngine;
using UnityEngine.UI;

public class SetLevelProperty : MonoBehaviour
{
    [SerializeField] private Text _needCountToasts;
    private int _defaultsCountToasts = 15;
    public void SetNeedCountToasts()
    {
        _needCountToasts.text = Convert.ToString(UnityEngine.Random.Range(15, 30));

    }
}
