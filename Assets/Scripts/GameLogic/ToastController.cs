using System;
using UnityEngine;
using UnityEngine.UI;

public class ToastController : MonoBehaviour
{
    [SerializeField] private Text _countDoneToasts;
    [SerializeField] private Text _needCountToasts;
    [SerializeField] private Text _currentlvl;
    [SerializeField] private Text _nextlvl;
    [SerializeField] private Image fillprogress;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _plateToasts;
    [SerializeField] private Animator _winAnim;
    [SerializeField] private ThiefAI _thief;
    private Vector3 _startPositionToast;
    private Quaternion _startRotation;
    private Renderer _rend;
    private int _lvlStep = 1;

    private void Start()
    {
        _startPositionToast = this.transform.position;
        _startRotation = this.transform.rotation;
        _rend = this.GetComponent<Renderer>();
    }
    private void OnMouseDown()
    {
        PositionReset();
        IncreaseCountToasts();
        _plateToasts.SetActive(true);
    }
    private void IncreaseCountToasts()
    {
        if (HeatTost._done)
        {
            int _toastCount = Convert.ToInt32(_countDoneToasts.text);
            _toastCount += 1;
            if (_toastCount % 2 == 0)
            {
                _thief.StartThief();
            }
            fillprogress.fillAmount = (float)Convert.ToInt32(_countDoneToasts.text) / Convert.ToInt32(_needCountToasts.text);
            _countDoneToasts.text = Convert.ToString(_toastCount);
            CheckWin();
        }
    }
    private void CheckWin()
    {
        if (Convert.ToInt32(_needCountToasts.text) == Convert.ToInt32(_countDoneToasts.text))
        {
            _currentlvl.text = Convert.ToString(Convert.ToInt32(_currentlvl.text) + _lvlStep);
            _nextlvl.text = Convert.ToString(Convert.ToInt32(_nextlvl.text) + _lvlStep);
            fillprogress.fillAmount = 0;
            _countDoneToasts.text = "0";
            _winAnim.SetTrigger("Win");
            if ((Convert.ToInt32(_currentlvl.text) % 2) == 0)
            {
                AdsCore.ShowAdsVideo("Interstitial_Android");
            }
            _menu.SetActive(true);
        }
    }
    public void PositionReset()
    {
        this.transform.rotation = _startRotation;
        this.transform.position = _startPositionToast;
        _rend.material.color = Color.white;
    }
}
