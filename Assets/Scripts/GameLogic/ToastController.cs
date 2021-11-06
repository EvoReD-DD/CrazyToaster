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
    private int _defaultsCountToasts = 15;
    private Vector3 _startPositionToast;
    private Quaternion _startRotation;
    private Renderer _rend;

    private void Start()
    {
        _startPositionToast = this.transform.position;
        _startRotation = this.transform.rotation;
        _rend = this.GetComponent<Renderer>();
        _needCountToasts.text = SaveData._countsToasts;
    }

    private void OnMouseDown()
    {
        PositionReset();
        IncreaseCountToasts();
    }
    private void IncreaseCountToasts()
    {
            int _toastCount = Convert.ToInt32(_countDoneToasts.text);
            _toastCount += 1;
            fillprogress.fillAmount += Convert.ToInt32(_toastCount) / Convert.ToInt32(_needCountToasts);
            _countDoneToasts.text = Convert.ToString(_toastCount);
            CheckWin();
    }
    private void CheckWin()
    {
        if (Convert.ToInt32(_needCountToasts.text) == Convert.ToInt32(_countDoneToasts.text))
        {
            _currentlvl.text = Convert.ToString(Convert.ToInt32(_currentlvl.text) + 1);
            _nextlvl.text = Convert.ToString(Convert.ToInt32(_nextlvl.text) + 1);
            fillprogress.fillAmount = 0;
        }
    }
    public void SetNeedCountToasts()
    {
        _needCountToasts.text = Convert.ToString(UnityEngine.Random.Range(15, 30));
    }
    private void PositionReset()
    {
        this.transform.rotation = _startRotation;
        this.transform.position = _startPositionToast;
        _rend.material.color = Color.white;
    }
}
