using System;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadData : MonoBehaviour
{
    [SerializeField] private Text _toastsCount;
    [SerializeField] private Text _currentLvl;
    [SerializeField] private Text _nextLvl;
    [SerializeField] private Text _needToastsCount;
    private void Awake()
    {
        _toastsCount.text = PlayerPrefs.GetString("_savedToastCount", _toastsCount.text);
        _currentLvl.text = PlayerPrefs.GetString("_currentLvl", _currentLvl.text);
        _nextLvl.text = PlayerPrefs.GetString("_nextLvl", _nextLvl.text);
        _needToastsCount.text = PlayerPrefs.GetString("_needToastsCount", _needToastsCount.text);
    }
#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        if (pause) 
        {
        PlayerPrefs.SetString("_savedToastCount", _toastsCount.text);
        PlayerPrefs.SetString("_currentLvl", _currentLvl.text);
        PlayerPrefs.SetString("_nextLvl", _nextLvl.text);
        PlayerPrefs.SetString("_needToastsCount", _needToastsCount.text);
        }
    }
#endif
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("_savedToastCount", _toastsCount.text);
        PlayerPrefs.SetString("_currentLvl", _currentLvl.text);
        PlayerPrefs.SetString("_nextLvl", _nextLvl.text);
        PlayerPrefs.SetString("_needToastsCount", _needToastsCount.text);
    }
}
